using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Level.Commands
{
    public class UpdateLevelCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public UpdateLevelCommand(string code, string name, string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }

        public class Handler : IRequestHandler<UpdateLevelCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(UpdateLevelCommand query, CancellationToken cancellationToken)
            {
                LevelItem exist = _unitOfWork.level.getLevel(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "Level not found", "", 404);
                }
                SqlLevel level = await _unitOfWork.level.updateLevel(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(level.code))
                {
                    return new ApiResponse(false, "Update level failed", "", 400);
                }
                return new ApiResponse(true, "Update level successfully", level.code, 200);
            }
        }
    }
}
