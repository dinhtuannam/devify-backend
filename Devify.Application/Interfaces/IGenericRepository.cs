using System.Linq.Expressions;

namespace Devify.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // ===================================== QUERIES ======================================= 
        IQueryable<T> GetCondition(Expression<Func<T, bool>> condition);
        IQueryable<T> GetAll();
        IQueryable<T> GetID(string code, int delete);
        IQueryable<T> GetCode(string code ,int delete);

        // ===================================== COMMANDS ======================================= 
        bool Insert(T entity);
        bool Delete(T entity); 
        bool Update(T entity);
        
    }
}
