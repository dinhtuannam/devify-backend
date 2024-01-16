using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


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
                RoleItem role = _unitOfWork.role.getRole(query.code);
                if (string.IsNullOrEmpty(role.code))
                {
                    return Task.FromResult(new ApiResponse(false, "role not found", role, 404));
                }
                return Task.FromResult(new ApiResponse(true, "get role successfully", role, 200));
            }
        }
    }
}
