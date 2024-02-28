using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.User.Commands
{
    public class UpdatePasswordCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string role { get; set; } = "";
        public string code { get; set; } = "";
        public string curPassword { get; set; } = "";
        public string newPassword { get; set; } = "";

        public UpdatePasswordCommand(string user, string role, string code, string curPassword, string newPassword)
        {
            this.user = user;
            this.role = role;
            this.code = code;
            this.curPassword = curPassword;
            this.newPassword = newPassword;
        }

        public class Handler : IRequestHandler<UpdatePasswordCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(UpdatePasswordCommand query, CancellationToken cancellationToken)
            {
                if(query.role.CompareTo("admin") != 0 && query.user.CompareTo(query.code) != 0)
                {
                    return new ApiResponse(false, "Bạn không có quyền thao tác", false, 403);
                }
                bool result = await _unitOfWork.user.updatePassword(query.code, query.curPassword, query.newPassword);
                if (!result)
                {
                    return new ApiResponse(false, "Mật khẩu hoặc tài khoản không trùng khớp", false, 400);
                }
                return new ApiResponse(true, "Đổi mật khẩu thành công", true, 200);
            }
        }
    }
}
