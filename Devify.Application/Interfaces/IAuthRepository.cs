using Devify.Entity;
using Devify.Application.DTO;

namespace Devify.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<SqlUser> Login(string name, string password);
        Task<ApiResponse> Register(string username, string password, string email, string phone);
        Task<ApiResponse> ValidateRegister(string username, string password, string email, string phone);

    }
}
