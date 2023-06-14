using Devify.Application;
using Devify.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Devify.Infrastructure
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string JWT_Key = "DEVIFY_AUTHENTICATE_JWT_KEY";
        private readonly UserManager<IdentityUser> _userManager;
       
        public AuthRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task AddAsAsync(RefreshToken token)
        {
            await _context.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<IdentityUser> Login(string name, string password)
        {
            return await _userManager.FindByEmailAsync(name);
        }

        public async Task<Token> GenerateToken(IdentityUser account)
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
                Expires = DateTime.UtcNow.AddMinutes(30),
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

        private DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
            return dateTimeInterval;
        }

        DateTime IAuthRepository.ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            throw new NotImplementedException();
        }

        public async Task<API_Response> RenewToken(Token model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(JWT_Key);
            var tokenParamValidate = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false
            };
            try
            {
                // check 1 : Access Token valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessToken, tokenParamValidate,
                    out var validatedToken);
                // check 2 : Check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals
                        (SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        return new API_Response{
                            Success= false,
                            Message= "Invalid token"
                        };
                    }
                }
                // check 3 : check accessToken expire ?
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x =>
                    x.Type == JwtRegisteredClaimNames.Exp).Value
                );
                var expiredDate = ConvertUnixTimeToDateTime(utcExpireDate);
                if (expiredDate > DateTime.UtcNow)
                    return new API_Response
                    {
                        Success = false,
                        Message = "Access token not yet expired"
                    };
                // check 4 : check refresh token exist in db ?
                var storedToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == model.RefreshToken);
                if (storedToken == null)
                    return new API_Response
                    {
                        Success = false,
                        Message = "Refresh token does not exist"
                    };
                // check 5 : check refresh token is used/revoked?
                if (storedToken.IsUsed)
                    return new API_Response
                    {
                        Success = false,
                        Message = "Refresh token has been used"
                    };
                if (storedToken.IsRevoked)
                    return new API_Response
                    {
                        Success = false,
                        Message = "Refresh token has been revoked"
                    };
                // check 6 : Access Token ID == JwtID in refresh token ?
                var jti = tokenInVerification.Claims.FirstOrDefault
                    (x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                if (storedToken.JwtId != jti)
                    return new API_Response
                    {
                        Success = false,
                        Message = "token doesnt match"
                    };
                // Update token is used
                storedToken.IsUsed = true;
                storedToken.IsRevoked = true;
                _context.Update(storedToken);
                await _context.SaveChangesAsync();
                var user = await _userManager.FindByIdAsync(storedToken.AccountId);
                var token = await GenerateToken(user);

                return new API_Response
                {
                    Success = true,
                    Message = "Renew Token Success",
                    Data = token
                };
            }
            catch (Exception ex)
            {
                return new API_Response
                {
                    Success = false,
                    Message = "Something went wrong"
                };
            }
        }
    }
}
