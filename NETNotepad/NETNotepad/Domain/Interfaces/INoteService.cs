using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Domain.Interfaces
{
    public interface INoteService : IBaseService<Note, NoteModel, NoteRepository>
    {
        Task AddNoteWithUserAsync(NoteModel model, string username);

        Task<ICollection<NoteModel>> GetAllNotesForAnUserAsync(string username);

        NoteModel GetNoteWithUserById(int id);
    }
}
