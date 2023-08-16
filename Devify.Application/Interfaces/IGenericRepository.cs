using System.Linq.Expressions;

namespace Devify.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(string id);
        Task<bool> AddAsAsync(T entity);
        Task<bool> DeleteAsAsync(T entity);
        bool UpdateEntity(T entity);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition);
        IQueryable<T> GetAll();
    }
}
