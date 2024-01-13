using Devify.Application.DTO;
using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface ITokenRepository
    {
        public TokenDecodedInfo DecodeToken(string token);
        public Task<TokenDTO> GenerateToken(string user);
        public Task<SqlToken> CreateToken(string accessToken, string refreshToken, string user);
        public Task<TokenDTO> RenewToken(string refreshToken);
        public Task<int> DeleteRevokedToken();
    }
}
