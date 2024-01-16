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
        public string password { get; set; } = "";
        public string displayName { get; set; } = "";
        public string email { get; set; } = "";
        public string image { get; set; } = "";
        public string social { get; set; } = "";
        public string about { get; set; } = "";
        public string role { get; set; } = "";
        public UpdateUserCommand(
            string user,
            string userRole,
            string code,
            string username,
            string password,
            string displayName,
            string email,
            string image,
            string social,
            string about,
            string role)
        {
            this.user = user;
            this.userRole = userRole;
            this.code = code;
            this.username = username;
            this.password = password;
            this.displayName = displayName;
            this.email = email;
            this.image = image;
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
                    return new ApiResponse(false, "You dont have permission", "", 403);
                }
                UserItem exist = _unitOfWork.user.getUser(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(true, "user not found", "", 400);
                }
                SqlUser newUser = await _unitOfWork.user.editUser(
                    query.code,
                    query.username,
                    query.password,
                    query.displayName,
                    query.email,
                    query.image,
                    query.social,
                    query.about,
                    query.role
                );

                if (string.IsNullOrEmpty(newUser.code))
                {
                    return new ApiResponse(false, "update user failed", "", 400);
                }
                return new ApiResponse(true, "update user successfully", newUser.code, 200);
            }
        }
    }
}
