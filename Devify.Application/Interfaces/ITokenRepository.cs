using Devify.Application.DTO;
using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface ITokenRepository
    {
        Task AddTokenAsync(SqlToken token);
        Task<Token> GenerateToken(SqlUser account);
        DateTime ConvertUnixTimeToDateTime(long utcExpireDate);
        Task<ApiResponse> RenewToken(string refreshTokenRequest);
        bool IsTokenIdEqualRequestId(string token, string requestId);
        bool ValidateToken(string token);
        TokenInfoDecoded DecodedToken(string token);    
    }
}
