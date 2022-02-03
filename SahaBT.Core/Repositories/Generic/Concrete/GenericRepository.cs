using Microsoft.EntityFrameworkCore;
using SahaBT.Core.EntityFramework.DatabaseContext;
using SahaBT.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SahaBT.Core.Repositories.Generic
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        protected readonly SahaBTContext _context;
        public GenericRepository(SahaBTContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
