using Devify.Application;
using Devify.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Devify.Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthRepository _refreshTokenRepository;
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Account GetById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccountId == id);
        }      
    }
}
