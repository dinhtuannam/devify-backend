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
                UserItem user = _unitOfWork.user.getUser(query.code);
                if (string.IsNullOrEmpty(user.code))
                {
                    return Task.FromResult(new ApiResponse(false, "user not found", user, 404));
                }
                return Task.FromResult(new ApiResponse(true, "Get list user successfully", user, 200));
            }
        }
    }
}
