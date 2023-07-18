using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> SearchAsAsync(string name);
    }
}
