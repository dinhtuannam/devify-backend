using Devify.Entity;
using Devify.Application.DTO;
using Microsoft.AspNetCore.Identity;

namespace Devify.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task AddAsAsync(RefreshToken token);
        Task<IdentityUser> Login(string name, string password);
        Task<API_Response> Register(RegisterRequest model);
        Task<API_Response> ValidateRegister(RegisterRequest model);
        Task<Token> GenerateToken(IdentityUser account);
        DateTime ConvertUnixTimeToDateTime(long utcExpireDate);
        Task<API_Response> RenewToken(Token model);

        /*Task<IdentityUser> Register(RegisterModel model);*/
    }
}
