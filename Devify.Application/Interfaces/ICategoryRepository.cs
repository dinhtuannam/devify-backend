using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<SqlCategory>
    {
        Task<IEnumerable<SqlCategory>> SearchAsAsync(string name);
    }
}
