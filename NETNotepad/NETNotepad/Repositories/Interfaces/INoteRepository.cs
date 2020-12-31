using NETNotepad.DomainModels;
using NETNotepad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Repositories.Interfaces
{
    public interface INoteRepository : IBaseRepository<Note, NoteModel>
    {
        Task AddNoteAsync(NoteModel model, string username);

        Task<ICollection<NoteModel>> GetAllNotesAsync(string username);

        NoteModel GetNoteByID(int id);
    }
}
