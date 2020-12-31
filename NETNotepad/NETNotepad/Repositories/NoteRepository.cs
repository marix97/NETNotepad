using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NETNotepad.Data;
using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Repositories
{
    public class NoteRepository : BaseRepository<Note, NoteModel>, INoteRepository
    {
        public NoteRepository(NotepadContext context, IMapper mapper) : base(context, mapper) { }

        public async Task AddNoteAsync(NoteModel model, string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            var note = _mapper.Map<Note>(model);

            note.User = user;

            Note existingRecord = _context.Notes.FirstOrDefault(u => u.Text == note.Text && u.Title == note.Title 
            && u.User == note.User);

            var notesCount = await this.GetAllNotesAsync(username);

            if (existingRecord is null && notesCount.Count < 5)
            {
                await _context.AddAsync(note);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<NoteModel>> GetAllNotesAsync(string username)
        {
            var notes = await _context.Notes.Include(t => t.User).Where(u => u.User.Username == username).ToListAsync();

            return _mapper.Map<List<NoteModel>>(notes);
        }

        public NoteModel GetNoteByID(int id)
        {
            var record = _context.Notes.Include(n => n.User).Where(n => n.ID == id);
            var note =  record.FirstOrDefault();

            return _mapper.Map<NoteModel>(note);
        }
    }
}
