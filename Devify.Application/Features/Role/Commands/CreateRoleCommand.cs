using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Role.Commands
{
    public class CreateRoleCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";

        public CreateRoleCommand(string code, string name, string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }

        public class Handler : IRequestHandler<CreateRoleCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(CreateRoleCommand query, CancellationToken cancellationToken)
            {
                SqlRole role = await _unitOfWork.role.createRole(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(role.code))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Create role failed",
                        data = "",
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Create role successfully",
                    data = role.code,
                    code = 200
                };
            }
        }
    }
}
