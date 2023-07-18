namespace Devify.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<bool> AddAsAsync(T entity);
        Task<bool> DeleteById(string id);
        Task<bool> UpdateAsAsync(T entity);

    }
}
