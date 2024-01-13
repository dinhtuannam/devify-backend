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
    public class GetUserQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetUserQuery(string code) { this.code = code; }
        public class Handler : IRequestHandler<GetUserQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetUserQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get list user successfully",
                    code = 0,
                    data = _unitOfWork.user.getUser(query.code)
                };
                return Task.FromResult(res);
            }
        }
    }
}
