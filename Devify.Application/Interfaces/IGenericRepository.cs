using System.Linq.Expressions;

namespace Devify.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(string id);
        Task<bool> AddAsAsync(T entity);
        Task<bool> DeleteById(string id);
        Task<bool> UpdateAsAsync(T entity);
        Task<List<T>> GetByCondition(Expression<Func<T, bool>> condition);
        IQueryable<T> GetAll();
    }
}
