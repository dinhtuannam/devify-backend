using Devify.Entity;
using Microsoft.AspNetCore.Identity;

namespace Devify.Application
{
    public interface IAuthRepository
    {
        Task AddAsAsync(RefreshToken token);
        Task<IdentityUser> Login(string name, string password);
        Task<Token> GenerateToken(IdentityUser account);
        DateTime ConvertUnixTimeToDateTime(long utcExpireDate);
        Task<API_Response> RenewToken(Token model);
    }
}
