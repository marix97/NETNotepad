using NETNotepad.Domain.Interfaces;
using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Domain
{
    public class NoteService : BaseService<Note, NoteModel, INoteRepository>, INoteService
    {
        public NoteService(INoteRepository repository) : base(repository) { }

        public async Task AddNoteWithUserAsync(NoteModel model, string username)
        {
            await _repository.AddNoteAsync(model, username);
        }

        public async Task<ICollection<NoteModel>> GetAllNotesForAnUserAsync(string username)
        {
            return await _repository.GetAllNotesAsync(username);
        }

        public NoteModel GetNoteWithUserById(int id)
        {
           return _repository.GetNoteByID(id);
        }
    }
}
