using Devify.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Devify.Infrastructure.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> getAccountInformation(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            return result;
        }
    }
}
