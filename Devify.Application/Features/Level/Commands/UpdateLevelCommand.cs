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
                SqlLevel level = await _unitOfWork.LevelRepository.updateLevel(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(level.code))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Update level failed",
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Update level successfully",
                    code = 0,
                    data = level.code
                };
            }
        }
    }
}
