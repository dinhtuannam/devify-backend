using AutoMapper;
using Devify.Application.DTO;
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
            private readonly IMapper _mapper;
            public LoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<ApiResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
            {
                var apiResponse = new ApiResponse
                {
                    result = true,
                    message = "Đăng nhập thành công",
                };
                var loginResult = await _unitOfWork.AuthRepository.Login(command.username, command.password);
                if(loginResult == null)
                {
                    apiResponse.result = false;
                    apiResponse.message = "Tên đăng nhập hoặc mật khẩu không đúng";
                    apiResponse.code = 500;
                    return apiResponse;
                }
                var userInformation = _mapper.Map<Account_Information_DTO>(loginResult);
                var tokenResult = await _unitOfWork.TokenRepository.GenerateToken(loginResult);
                if(tokenResult == null)
                {
                    apiResponse.result = false;
                    apiResponse.message = "Đã xảy ra lỗi vui lòng thử lại sau";
                    apiResponse.code = 500;
                    return apiResponse;
                }
               /* var responseData = new LoginResponse
                {
                    AccessToken = tokenResult.AccessToken,
                    RefreshToken = tokenResult.RefreshToken,
                    Info = userInformation
                };
                apiResponse.Data = responseData;*/
                return apiResponse;
            }
        }
    }
}
