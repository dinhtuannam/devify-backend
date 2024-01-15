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
    public class GetListRoleQuery : IRequest<ApiResponse>
    {
        public class Handler : IRequestHandler<GetListRoleQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetListRoleQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get list role successfully",
                    code = 0,
                    data = _unitOfWork.role.getListRole()
                };
                return Task.FromResult(res);
            }
        }
    }
}
