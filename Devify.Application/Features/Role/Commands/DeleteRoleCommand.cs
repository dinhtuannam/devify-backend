using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Role.Commands
{
    public class DeleteRoleCommand : IRequest<ApiResponse>
    {
        public string code { get; set; }
        public DeleteRoleCommand(string code)
        {
            this.code = code;
        }
        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteRoleCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(DeleteRoleCommand query, CancellationToken cancellationToken)
            {
                bool res = await _unitOfWork.role.deleteRole(query.code);
                if (!res)
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Delete role failed",
                        data = res,
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Delete role successfully",
                    data = res,
                    code = 200
                };
            }
        }
    }
}
