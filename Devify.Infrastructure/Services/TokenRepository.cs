using Devify.Application.DTO;
using Devify.Application.DTO.ResponseDTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Devify.Infrastructure.Services
{
    public class TokenRepository : ITokenRepository
    {
        private readonly string JWT_Key = "DEVIFY_AUTHENTICATE_JWT_KEY";
        private readonly string ValidAudience = "User";
        private readonly string ValidIssuer = "https://localhost:7221";
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public TokenRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task AddAsAsync(RefreshToken token)
        {
            await _context.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
            return dateTimeInterval;
        }

        public async Task<Token> GenerateToken(ApplicationUser account)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(JWT_Key);
            var roles = await _userManager.GetRolesAsync(account);
            var roleName = roles[0];
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Id", account.Id.ToString()),
                    new Claim("RoleId", roleName),

                }),
                Issuer = ValidIssuer,
                Audience = ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                AccountId = account.Id,
                JwtId = token.Id,
                Token = refreshToken,
                IsRevoked = false,
                IsUsed = false,
                Expired = DateTime.UtcNow.AddMinutes(2)
            };
            await AddAsAsync(refreshTokenEntity);
            return new Token
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        public bool IsTokenIdEqualRequestId(string token, string requestId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(token);
            var claimId = decodedToken.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;
            if (!string.IsNullOrEmpty(claimId) && claimId == requestId)
            {
                return true;
            }
            return false;
        }

        public async Task<ApiResponse> RenewToken(string refreshTokenRequest)
        {
            try
            {
                // check 4 : check refresh token exist in db ?
                var storedToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == refreshTokenRequest);
                if (storedToken == null)
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token does not exist"
                    };
                // check 5 : check refresh token is used/revoked?
                if (storedToken.IsUsed)
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token has been used"
                    };
                if (storedToken.IsRevoked)
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token has been revoked"
                    };
                // Update token is used
                storedToken.IsUsed = true;
                storedToken.IsRevoked = true;
                _context.Update(storedToken);
                await _context.SaveChangesAsync();
                var user = await _userManager.FindByIdAsync(storedToken.AccountId);
                var token = await GenerateToken(user);

                return new ApiResponse
                {
                    Success = true,
                    Message = "Renew Token Success",
                    Data = token
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Something went wrong"
                };
            }
        }

        private TokenValidationParameters GetValidationParameters(bool isValidateLifetime = true)
        {
            var secretKeyBytes = Encoding.UTF8.GetBytes(JWT_Key);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = ValidAudience,
                ValidIssuer = ValidIssuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = isValidateLifetime
            };

            return validationParameters;
        }
        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameter = GetValidationParameters();
            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameter, out _);
                var expirationDateUnix = long.Parse(claimsPrincipal.FindFirst("exp")?.Value);
                var expirationDate = DateTimeOffset.FromUnixTimeSeconds(expirationDateUnix).DateTime;
                if (expirationDate <= DateTime.UtcNow)
                    return false;
                return true;
            }
            catch (SecurityTokenException)
            {
                // Lỗi xác thực token
                return false;
            }
            catch (Exception)
            {
                // Lỗi khác
                return false;
            }
        }
    }
}
