using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Level.Queries
{
    public class GetAllLevelQuery : IRequest<ApiResponse>
    {
        public class Handler : IRequestHandler<GetAllLevelQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetAllLevelQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get list level successfully",
                    code = 0,
                    data = _unitOfWork.LevelRepository.getAllLevel()
                };
                return Task.FromResult(res);
            }
        }
    }
}
