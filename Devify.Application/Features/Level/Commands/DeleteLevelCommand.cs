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
    public class DeleteLevelCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";

        public DeleteLevelCommand(string code)
        {
            this.code = code;
        }

        public class Handler : IRequestHandler<DeleteLevelCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(DeleteLevelCommand query, CancellationToken cancellationToken)
            {
                bool res = await _unitOfWork.LevelRepository.deleteLevel(query.code);
                if (!res)
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Delete level failed",
                        code = 400,
                        data = false
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Create level successfully",
                    code = 0,
                    data = true
                };
            }
        }
    }
}
