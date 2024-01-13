using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.User.Queries
{
    public class GetUserByNameQuery : IRequest<ApiResponse>
    {
        public string name { get; set; } = "";
        public GetUserByNameQuery(string name) { this.name = name; }
        public class Handler : IRequestHandler<GetUserByNameQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetUserByNameQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get list user successfully",
                    code = 0,
                    data = _unitOfWork.user.getUserByName(query.name)
                };
                return Task.FromResult(res);
            }
        }
    }
}
