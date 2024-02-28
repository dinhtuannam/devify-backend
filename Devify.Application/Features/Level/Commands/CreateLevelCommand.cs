using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;


namespace Devify.Application.Features.Level.Commands
{
    public class CreateLevelCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public CreateLevelCommand(string code, string name,string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }

        public class Handler : IRequestHandler<CreateLevelCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(CreateLevelCommand query, CancellationToken cancellationToken)
            {
                LevelItem exist = _unitOfWork.level.getLevel(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "Level not found", "", 404);
                }
                SqlLevel level = await _unitOfWork.level.createLevel(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(level.code))
                {
                    return new ApiResponse(false, "Create level failed", "", 400);
                }
                await _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.level);
                return new ApiResponse(true, "Create level successfully", level.code, 200);
            }
        }
    }
}
