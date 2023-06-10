using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application
{
    public interface IAuthRepository
    {
        Task AddAsAsync(RefreshToken token);
        Account Login(string name, string password);
        Task<Token> GenerateToken(Account account);
        DateTime ConvertUnixTimeToDateTime(long utcExpireDate);
        Task<API_Response> RenewToken(Token model);
    }
}
