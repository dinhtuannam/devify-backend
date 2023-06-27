using Devify.Entity;
using Devify.Application.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

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
        bool IsTokenIdEqualRequestId(string token, string requestId);
        bool ValidateToken(string token);
   
        

        /*Task<IdentityUser> Register(RegisterModel model);*/
    }
}
