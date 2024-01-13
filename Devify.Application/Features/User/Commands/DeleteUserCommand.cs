using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.User.Commands
{
    public class DeleteUserCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";

        public DeleteUserCommand(string code)
        {
            this.code = code;
        }

        public class Handler : IRequestHandler<DeleteUserCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(DeleteUserCommand query, CancellationToken cancellationToken)
            {
                bool res = await _unitOfWork.user.deleteUser(query.code);
                if (!res)
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Delete user failed",
                        code = 400,
                        data = false
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Delete user successfully",
                    code = 200,
                    data = true
                };
            }
        }
    }
}
