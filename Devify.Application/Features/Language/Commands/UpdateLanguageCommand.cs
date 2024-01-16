using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;

namespace Devify.Application.Features.Language.Commands
{
    public class UpdateLanguageCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public UpdateLanguageCommand(string code,string name,string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }
        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(UpdateLanguageCommand query, CancellationToken cancellationToken)
            {
                LanguageItem lang = _unitOfWork.language.getLanguage(query.code);
                if (string.IsNullOrEmpty(lang.code))
                {
                    return new ApiResponse(false, "language not found", lang, 404);
                }
                SqlLanguage result = await _unitOfWork.language.updateLanguage(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(result.code))
                {
                    return new ApiResponse(false, "Update language failed", "", 400);
                }
                return new ApiResponse(true, "Update language successfully", result.code, 200);
            }
        }
    }
}
