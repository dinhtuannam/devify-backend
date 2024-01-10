using Devify.Application.DTO;
using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface IAccountRepository : IGenericRepository<SqlUser>
    {
        public Task<SqlUser> getCurrentUser(string id);
        public Task<SqlUser> getUserByName(string name);
        public Task<DetailAccountDTO> getUserById(string id);
    }
}
