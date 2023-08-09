using Devify.Entity;
using Devify.Application.DTO.RequestDTO;
using Devify.Application.DTO.ResponseDTO;
using Devify.Application.DTO;

namespace Devify.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<ApplicationUser> Login(string name, string password);
        Task<ApiResponse> Register(RegisterRequest model);
        Task<ApiResponse> ValidateRegister(RegisterRequest model);

    }
}
