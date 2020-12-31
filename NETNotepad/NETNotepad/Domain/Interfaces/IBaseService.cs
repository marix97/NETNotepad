using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Domain.Interfaces
{
    public interface IBaseService<TEntity, TModel, TRepository>
        where TEntity : BaseEntity
        where TModel : BaseModel
        where TRepository : IBaseRepository<TEntity, TModel>
    {
        Task<TModel> GetByIdIfExistsAsync(int id);
        Task AddAsync(TModel model);
        Task<TModel> UpdateAsync(int id, TModel model);
        Task DeleteAsync(int id);
    }
}
