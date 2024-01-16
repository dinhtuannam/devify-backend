using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Level.Queries
{
    public class GetLevelQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetLevelQuery(string code)
        {
            this.code = code;
        }
        public class Handler : IRequestHandler<GetLevelQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetLevelQuery query, CancellationToken cancellationToken)
            {
                LevelItem level = _unitOfWork.level.getLevel(query.code);
                if (string.IsNullOrEmpty(level.code))
                {
                    return Task.FromResult(new ApiResponse(false, "level not found", level, 404));
                }
                return Task.FromResult(new ApiResponse(true, "get level successfully", level, 200));
            }
        }
    }
}
