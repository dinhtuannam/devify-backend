using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.User.Commands
{
    public class DeleteUserCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";

        public DeleteUserCommand(string code)
        {
            this.code = code;
        }

        public class Handler : IRequestHandler<DeleteUserCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(DeleteUserCommand query, CancellationToken cancellationToken)
            {
                UserItem exist = _unitOfWork.user.getUser(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "user not found", false, 404);
                }
                bool user = await _unitOfWork.user.deleteUser(query.code);
                if (!user)
                {
                    return new ApiResponse(false, "Delete user failed", false, 400);
                }
                return new ApiResponse(true, "Delete user successfully", true, 200);
            }
        }
    }
}
