using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.User.Commands
{
    public class SignInCommand : IRequest<ApiResponse>
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";

        public SignInCommand(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public class Handler : IRequestHandler<SignInCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(SignInCommand query, CancellationToken cancellationToken)
            {
                UserSignInInfo data = new UserSignInInfo();
                UserItem user = _unitOfWork.user.signIn(query.username, query.password);
                if (string.IsNullOrEmpty(user.code))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Username or password are not correct",
                        code = 404,
                        data = data
                    };
                }
                TokenDTO token = await _unitOfWork.token.GenerateToken(user.code);
                if(string.IsNullOrEmpty(token.AccessToken))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Something wrong please try again",
                        code = 500,
                        data = data
                    };
                }
                data.info = user;
                data.token = token;
                return new ApiResponse()
                {
                    result = true,
                    message = "Sign in successfully",
                    code = 200,
                    data = data
                };
            }
        }
    }
}
