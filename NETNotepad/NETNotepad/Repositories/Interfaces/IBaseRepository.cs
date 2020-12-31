using NETNotepad.DomainModels;
using NETNotepad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        public Task CreateAsync(TModel model);
        public Task DeleteAsync(int id);
        public Task<TModel> UpdateAsync(int id, TModel model);
        public Task<TModel> GetByIdAsync(int id);
    }
}
