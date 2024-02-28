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

namespace Devify.Application.Features.Role.Commands
{
    public class UpdateRoleCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public UpdateRoleCommand(string code, string name, string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }
        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateRoleCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(UpdateRoleCommand query, CancellationToken cancellationToken)
            {
                RoleItem exist = _unitOfWork.role.getRole(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "role not found", "", 404);
                }
                SqlRole role = await _unitOfWork.role.updateRole(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(role.code))
                {
                    return new ApiResponse(false, "update role failed", "", 400);
                }

                await Task.WhenAll(
                   _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.role),
                   _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.user)
                );

                return new ApiResponse(true, "update role successfully", role.code, 200);
            }
        }
    }
}
