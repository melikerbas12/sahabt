using SahaBT.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SahaBT.Core.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        void Delete(T entity);
        T Update(T entity);
    }
}
