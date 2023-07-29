using Devify.Application.Commons;
using Devify.Application.DTO;
using Devify.Application.DTO.ResponseDTO;
using Devify.Application.Features.Course.Commands;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<ApiResponse>
    {
        public string username { get; set; }
        public string password { get; set; }
        public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public LoginCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
            {
                var apiResponse = new ApiResponse
                {
                    Success = true,
                    Message = "Đăng nhập thành công",
                };
                var loginResult = await _unitOfWork.AuthRepository.Login(command.username, command.password);
                if(loginResult == null)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return apiResponse;
                }
                var tokenResult = await _unitOfWork.TokenRepository.GenerateToken(loginResult);
                if(tokenResult == null)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "Đã xảy ra lỗi vui lòng thử lại sau";
                    return apiResponse;
                }
                apiResponse.Data = tokenResult;
                return apiResponse;
            }
        }
    }
}
