using Devify.Application.DTO;
using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface IAccountRepository : IGenericRepository<ApplicationUser>
    {
        public Task<ApplicationUser> getCurrentUser(string id);
        public Task<ApplicationUser> getUserByName(string name);
        public Task<DetailAccountDTO> getUserById(string id);
    }
}
