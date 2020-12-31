using NETNotepad.Domain.Interfaces;
using NETNotepad.DomainModels;
using NETNotepad.Entities;
using NETNotepad.Repositories;
using NETNotepad.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETNotepad.Domain
{
    public abstract class BaseService<TEntity, TModel, TRepository> : IBaseService<TEntity, TModel, TRepository>
        where TEntity : BaseEntity
        where TModel : BaseModel
        where TRepository : IBaseRepository<TEntity, TModel>
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<TModel> GetByIdIfExistsAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TModel> UpdateAsync(int id, TModel model)
        {
            return await _repository.UpdateAsync(id, model);
        }
    }
}
