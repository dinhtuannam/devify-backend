using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.User.Commands
{
    public class CreateUserCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string userRole { get; set; } = "";
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public string displayName { get; set; } = "";
        public string email { get; set; } = "";
        public string role { get; set; } = "";
        public CreateUserCommand(string user,string userRole, string username, string password, string displayName,string email,string role)
        {
            this.user = user;
            this.userRole = userRole;
            this.username = username;
            this.password = password;
            this.displayName = displayName;
            this.email = email;
            this.role = role;
        }

        public class Handler : IRequestHandler<CreateUserCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateUserCommand query, CancellationToken cancellationToken)
            {
                bool flag = false;
                if (!string.IsNullOrEmpty(query.user) && !string.IsNullOrEmpty(query.userRole))
                {
                    switch(query.userRole)
                    {
                        case "manager":
                            if(query.role.CompareTo("admin") == 0)
                            {
                                flag = true;
                            }
                            break;
                        case "creator":
                            if (query.role.CompareTo("admin") == 0 || query.role.CompareTo("manager") == 0)
                            {
                                flag = true;
                            }
                            break;
                        case "customer":
                            if (query.role.CompareTo("admin") == 0 || query.role.CompareTo("manager") == 0)
                            {
                                flag = true;
                            }
                            break;
                    }
                }
                else
                {
                    if (query.role.CompareTo("admin") == 0 || query.role.CompareTo("manager") == 0)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    return new ApiResponse(false, "Bạn không có quyền thực hiện", "", 403);
                }
                UserItem exist_displayName = _unitOfWork.user.getUserByName(query.displayName);
                if (!string.IsNullOrEmpty(exist_displayName.code))
                {
                    return new ApiResponse(false, "Tên hiển thị đã có người sử dụng", "", 400);
                }
                UserItem exist_username = _unitOfWork.user.getUserByUsername(query.username);
                if (!string.IsNullOrEmpty(exist_username.code))
                {
                    return new ApiResponse(false, "Tên đăng nhập đã có người sử dụng", "", 400);
                }
                SqlUser newUser = await _unitOfWork.user.createUser(query.username, query.password, query.displayName, query.email, query.role);
                if (string.IsNullOrEmpty(newUser.code))
                {
                    return new ApiResponse(false, "Tạo tài khoản thất bại", "", 400);
                }

                await _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.user);

                return new ApiResponse(true, "Tạo tài khoản thành công", newUser.code, 200);
            }
        }
    }
}
