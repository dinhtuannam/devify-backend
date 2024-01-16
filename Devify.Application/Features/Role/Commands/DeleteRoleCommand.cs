using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

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
                RoleItem exist = _unitOfWork.role.getRole(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "role not found", false, 404);
                }
                bool role = await _unitOfWork.role.deleteRole(query.code);
                if (!role)
                {
                    return new ApiResponse(false, "Delete role failed", false, 400);
                }
                return new ApiResponse(true, "Delete role successfully", true, 200);
            }
        }
    }
}
