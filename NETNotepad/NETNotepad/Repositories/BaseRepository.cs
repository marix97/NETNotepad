using AutoMapper;
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
    public abstract class BaseRepository<TEntity, TModel> : IBaseRepository<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        protected readonly NotepadContext _context;
        protected readonly IMapper _mapper;

        public BaseRepository(NotepadContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(TModel model)
        {
            var recordToCreate = _mapper.Map<TEntity>(model);

            await _context.AddAsync(recordToCreate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var recordToDelete = await _context.Set<TEntity>().FindAsync(id);

            _context.Set<TEntity>().Remove(recordToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            var record = await _context.Set<TEntity>().FindAsync(id);

            return _mapper.Map<TModel>(record);
        }

        public async Task<TModel> UpdateAsync(int id, TModel model)
        {
            var entity = _context.Set<TEntity>().Find(id);

            if (entity == null)
            {
                return null;
            }

            try
            {
                _context.Entry(entity).CurrentValues.SetValues(model);
                await _context.SaveChangesAsync();

                return _mapper.Map<TModel>(entity);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"{nameof(model)} could not be updated. {e.Message} {e.InnerException}");
            }
        }
    }
}
