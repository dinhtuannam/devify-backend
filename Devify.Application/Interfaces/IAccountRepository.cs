using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface IAccountRepository
    {
        public Task<ApplicationUser> getAccountInformation(string id);
    }
}
