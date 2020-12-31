using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETNotepad.Domain.Interfaces;
using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Models;

namespace NETNotepad.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public HomeController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNote note)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;

                var noteModel = new NoteModel();

                noteModel.DateCreated = DateTime.Now;
                noteModel.Text = note.Text;
                noteModel.Title = note.Title;

                await _noteService.AddNoteWithUserAsync(noteModel, username);

                return Redirect("/Home/ViewNote");
            }

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var usernameForNote = _noteService.GetNoteWithUserById(id);

            if (usernameForNote.User.Username == User.Identity.Name)
            {
                var note = await _noteService.GetByIdIfExistsAsync(id);

                if (note is null)
                {
                    return Redirect("/Home/Index");
                }

                return View(_mapper.Map<NoteResponseModel>(note));
            }

            return Redirect("/Home/ViewNote");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _noteService.DeleteAsync(id);
            return Redirect("/Home/ViewNote");
        }

        [HttpGet]
        public async Task<IActionResult> ViewNote()
        {
            var username = User.Identity.Name;

            var notes = await _noteService.GetAllNotesForAnUserAsync(username);

            return View(_mapper.Map<ICollection<NoteResponseModel>>(notes));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var note = _noteService.GetNoteWithUserById(id);

            if(note.User.Username != User.Identity.Name)
            {
                return Redirect("/Home/ViewNote");
            }

            return View(_mapper.Map<NoteResponseModel>(note));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var note = _noteService.GetNoteWithUserById(id);

            if(note.User.Username != User.Identity.Name)
            {
                return Redirect("/Home/ViewNote");
            }

            return View(_mapper.Map<NoteResponseModel>(note));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditNote noteModel)
        {
            if (ModelState.IsValid)
            {
                var note = _mapper.Map<NoteModel>(noteModel);

                note.DateCreated = DateTime.Now;

                await _noteService.UpdateAsync(note.ID, note);

                return Redirect("/Home/ViewNote");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
