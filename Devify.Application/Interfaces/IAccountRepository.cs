using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface IAccountRepository
    {
        public Task<ApplicationUser> getCurrentUser(string id);
        public Task<ApplicationUser> getUserByName(string name);
    }
}
