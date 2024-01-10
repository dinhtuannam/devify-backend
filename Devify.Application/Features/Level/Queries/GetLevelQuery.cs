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
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get level successfully",
                    code = 0,
                    data = _unitOfWork.LevelRepository.getLevel(query.code)
                };
                return Task.FromResult(res);
            }
        }
    }
}
