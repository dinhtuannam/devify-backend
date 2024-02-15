using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Devify.Infrastructure.Services
{
    public class TokenRepository : GenericRepository<SqlToken>, ITokenRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public TokenRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SqlToken> CreateToken(string accessToken, string refreshToken, string user)
        {
            try
            {
                SqlUser? m_user = _context.users!.Where(s => s.code.CompareTo(user) == 0).Include(s => s.tokens).FirstOrDefault();
                if (m_user == null)
                {
                    return new SqlToken();
                }
                SqlToken? m_token = _context.tokens!.Where(s => s.accessToken.CompareTo(accessToken) == 0 &&
                                                               s.refreshToken.CompareTo(refreshToken) == 0 &&
                                                               s.isExpired == false)
                                                   .Include(s => s.user)
                                                   .FirstOrDefault();
                if (m_token != null)
                {
                    return new SqlToken();
                }
                SqlToken token = new SqlToken();
                token.id = DateTime.Now.Ticks;
                token.accessToken = accessToken;
                token.refreshToken = refreshToken;
                token.createTime = DateTime.Now;
                token.expiredTime = ConfigKey.getRTExpiredTime();
                token.isExpired = false;
                token.user = m_user; ;
                _context.tokens!.Add(token);
                int row = await _context.SaveChangesAsync();
                if (row <= 0)
                {
                    return new SqlToken();
                }
                return token;
            }
            catch (Exception ex)
            {
                Log.Error($"func: CreateToken -  with user: {user} -> failed , Exception: {ex.InnerException}");
                return new SqlToken();
            }

        }

        public async Task<TokenDTO> GenerateToken(string user)
        {
            try
            {
                UserItem info = _unitOfWork.user.getUser(user);
                if (string.IsNullOrEmpty(info.code))
                {
                    return new TokenDTO();
                }
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var secretKeyBytes = Encoding.UTF8.GetBytes(ConfigKey.JWT_KEY);
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                    new Claim("code", info.code),
                    new Claim("username", info.username),
                    new Claim("roleId",info.role != null ? info.role : ""),

                }),
                    Issuer = ConfigKey.VALID_ISSUER,
                    Audience = ConfigKey.VALID_AUDIENCE,
                    Expires = ConfigKey.getATExpiredTime(),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                    (secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = jwtTokenHandler.CreateToken(tokenDescription);
                var accessToken = jwtTokenHandler.WriteToken(token);
                var refreshToken = GenerateRefreshToken();

                SqlToken newToken = await CreateToken(accessToken, refreshToken, info.code);

                return new TokenDTO
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
            }
            catch (Exception ex)
            {
                Log.Error($"func: GenerateToken -  with user: {user} -> failed , Exception: {ex.InnerException}");
                return new TokenDTO();
            }

        }

        private string GenerateRefreshToken()
        {
            return DataContext.randomString(16);
        }

        public async Task<TokenDTO> RenewToken(string refreshToken)
        {
            try
            {
                SqlToken? checkToken = _context.tokens!.Where(x => x.refreshToken.CompareTo(refreshToken) == 0 && x.isExpired == false).Include(s => s.user).FirstOrDefault();
                if (checkToken == null)
                {
                    return new TokenDTO();
                }

                checkToken.isExpired = true;
                await _context.SaveChangesAsync();

                SqlUser? user = _context.users!.Where(s => s.code.CompareTo(checkToken.user!.code) == 0 && s.isdeleted == false).Include(s => s.role).FirstOrDefault();
                if(user == null)
                {
                    return new TokenDTO();
                }
                TokenDTO token = await GenerateToken(user.code);
                return token;
            }
            catch (Exception ex)
            {
                Log.Error($"func: RenewToken -> with refreshToken: {refreshToken} -> failed , Exception: {ex.InnerException}");
                return new TokenDTO();
            }
        }

        public TokenDecodedInfo DecodeToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secretKeyBytes = Encoding.UTF8.GetBytes(ConfigKey.JWT_KEY);
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = ConfigKey.VALID_AUDIENCE,
                    ValidIssuer = ConfigKey.VALID_ISSUER,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true
                };

                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                TokenDecodedInfo tokenInfo = new TokenDecodedInfo
                {
                    code = principal.FindFirst("code")?.Value,
                    role = principal.FindFirst("roleId")?.Value,
                    username = principal.FindFirst("username")?.Value,
                };

                return tokenInfo;
            }
            catch (Exception ex)
            {
                Log.Error($"func: DecodeToken -> with token: {token} -> failed , Exception: {ex.InnerException}");
                return new TokenDecodedInfo();
            }
        }

        public async Task<int> DeleteRevokedToken()
        {
            try
            {
                DateTime now = DateTime.Now;
                List<SqlToken> tokens = _context.tokens.Where(s => s.isExpired == true || DateTime.Compare(s.expiredTime, now) <= 0).ToList();
                if (tokens.Count <= 0)
                {
                    return 0;
                }
                _context.RemoveRange(tokens);
                int rows = await _context.SaveChangesAsync();
                Log.Information($"func: DeleteRevokedToken -> remove {rows} items ");
                return rows;
            }
            catch (Exception ex)
            {
                Log.Error($"func: DeleteRevokedToken -> failed , Exception: {ex.InnerException}");
                return 0;
            }

        }
    }
}
