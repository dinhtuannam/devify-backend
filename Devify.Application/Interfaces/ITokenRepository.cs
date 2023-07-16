using Devify.Application.DTO.ResponseDTO;
using Devify.Application.DTO;
using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface ITokenRepository
    {
        Task AddAsAsync(RefreshToken token);
        Task<Token> GenerateToken(ApplicationUser account);
        DateTime ConvertUnixTimeToDateTime(long utcExpireDate);
        Task<ApiResponse> RenewToken(string refreshTokenRequest);
        bool IsTokenIdEqualRequestId(string token, string requestId);
        bool ValidateToken(string token);
    }
}
