using Devify.Application.Interfaces;
using Devify.Entity;
using Microsoft.AspNetCore.Identity;
using System.Threading;

namespace Devify.Infrastructure.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> getCurrentUser(string id)
        {
            try
            {
                var result = await _userManager.FindByIdAsync(id);
                Console.WriteLine($"[AccountService] -> getAccountInformation with id:{id} -> successfully");
                return result;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"[AccountService] -> getAccountInformation with id:{id} -> failed -> ex: {ex} ");
                return null;
            }
            
        }

        public async Task<ApplicationUser> getUserByName(string name)
        {
            try
            {
                var result = await _userManager.FindByNameAsync(name);
                Console.WriteLine($"[AccountService] -> getUserByName with id:{name} -> successfully");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AccountService] -> getUserByName with id:{name} -> failed -> ex: {ex} ");
                return null;
            }
        }
    }
}
