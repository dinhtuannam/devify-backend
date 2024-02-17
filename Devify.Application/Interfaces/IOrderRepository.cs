using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface IOrderRepository : IGenericRepository<SqlOrder>
    {
        Task<bool> CheckOut(string user);
    }
}
