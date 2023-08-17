using System.Linq.Expressions;

namespace Devify.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // ===================================== QUERIES ======================================= 
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll(string[] includes = null);
        Task<T> GetById(string id);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition);
        int CountRecords(Expression<Func<T, bool>> where = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);


        // ===================================== COMMANDS ======================================= 
        Task<bool> AddAsAsync(T entity);
        Task<bool> DeleteAsAsync(T entity); 
        bool UpdateEntity(T entity);
        
    }
}
