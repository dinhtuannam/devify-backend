using Devify.Application.Interfaces;
using Devify.Entity;
using Microsoft.AspNetCore.Identity;

namespace Devify.Infrastructure.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> getAccountInformation(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            return result;
        }
    }
}
