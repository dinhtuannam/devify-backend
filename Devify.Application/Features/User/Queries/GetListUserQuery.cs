using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.User.Queries
{
    public class GetListUserQuery : IRequest<ApiResponse>
    {
        public class Handler : IRequestHandler<GetListUserQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetListUserQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get list user successfully",
                    code = 200,
                    data = _unitOfWork.user.getListUser()
                };
                return Task.FromResult(res);
            }
        }
    }
}
