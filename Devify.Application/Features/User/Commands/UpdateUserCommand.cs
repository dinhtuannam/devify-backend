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
    public class UpdateUserCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string userRole { get; set; } = "";
        public string code { get; set; } = "";
        public string username { get; set; } = "";
        public string displayName { get; set; } = "";
        public string email { get; set; } = "";
        public string social { get; set; } = "";
        public string about { get; set; } = "";
        public string role { get; set; } = "";
        public UpdateUserCommand(
            string user,
            string userRole,
            string code,
            string username,
            string displayName,
            string email,
            string social,
            string about,
            string role)
        {
            this.user = user;
            this.userRole = userRole;
            this.code = code;
            this.username = username;
            this.displayName = displayName;
            this.email = email;
            this.social = social;
            this.about = about;
            this.role = role;
        }
        public class Handler : IRequestHandler<UpdateUserCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(UpdateUserCommand query, CancellationToken cancellationToken)
            {
                UserItem user = new UserItem();
                bool flag = false;
                if (!string.IsNullOrEmpty(query.user) && !string.IsNullOrEmpty(query.userRole))
                {
                    switch (query.userRole)
                    {
                        case "manager":
                            if (query.role.CompareTo("admin") == 0)
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
                    return new ApiResponse(false, "Bạn không có quyền truy cập", user, 403);
                }
                UserItem exist = _unitOfWork.user.getUser(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "Không tìm thấy người dùng", user, 400);
                }
                if(exist.displayName.CompareTo(query.displayName) != 0)
                {
                    UserItem exist_displayName = _unitOfWork.user.getUserByName(query.displayName);
                    if (!string.IsNullOrEmpty(exist_displayName.code))
                    {
                        return new ApiResponse(false, "Tên hiển thị đã có người sử dụng", user, 400);
                    }
                }
                if (exist.username.CompareTo(query.username) != 0)
                {
                    UserItem exist_username = _unitOfWork.user.getUserByUsername(query.username);
                    if (!string.IsNullOrEmpty(exist_username.code))
                    {
                        return new ApiResponse(false, "Tên đăng nhập đã có người sử dụng", user, 400);
                    }
                }
                
                SqlUser newUser = await _unitOfWork.user.editUser(
                    query.code,
                    query.username,
                    query.displayName,
                    query.email,
                    query.social,
                    query.about,
                    query.role
                );

                if (string.IsNullOrEmpty(newUser.code))
                {
                    return new ApiResponse(false, "Cập nhật thất bại", user, 400);
                }
                
                await Task.WhenAll(
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.user),
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.course),
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.inventory)
                );
                user = _unitOfWork.user.getUser(query.code);
                return new ApiResponse(true, "Cập nhật thành công", user, 200);
            }
        }
    }
}
