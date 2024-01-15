using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Role.Queries
{
    public class GetRoleQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetRoleQuery(string code)
        {
            this.code = code;
        }
        public class Handler : IRequestHandler<GetRoleQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetRoleQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get role successfully",
                    code = 0,
                    data = _unitOfWork.role.getRole(query.code)
                };
                return Task.FromResult(res);
            }
        }
    }
}
