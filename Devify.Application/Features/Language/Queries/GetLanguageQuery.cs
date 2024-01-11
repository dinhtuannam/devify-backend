using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Language.Queries
{
    public class GetLanguageQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetLanguageQuery(string code)
        {
            this.code = code;
        }
        public class Handler : IRequestHandler<GetLanguageQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetLanguageQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get language successfully",
                    code = 0,
                    data = _unitOfWork.LanguageRepository.getLanguage(query.code)
                };
                return Task.FromResult(res);
            }
        }
    }
}
