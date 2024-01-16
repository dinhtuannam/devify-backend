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
                LanguageItem lang = _unitOfWork.language.getLanguage(query.code);
                if (string.IsNullOrEmpty(lang.code))
                {
                    return Task.FromResult(new ApiResponse(false, "language not found", lang, 404));
                }
                return Task.FromResult(new ApiResponse(true, "get lang successfully", lang, 200));
            }
        }
    }
}
