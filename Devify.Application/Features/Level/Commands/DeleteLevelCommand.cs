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
                LevelItem exist = _unitOfWork.level.getLevel(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "Level not found", false, 404);
                }
                bool level = await _unitOfWork.level.deleteLevel(query.code);
                if (!level)
                {
                    return new ApiResponse(false, "Delete level failed", false, 400);
                }
                await Task.WhenAll(
                   _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.level),
                   _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.course)
                );
                return new ApiResponse(true, "Delete level successfully", true, 200);
            }
        }
    }
}
