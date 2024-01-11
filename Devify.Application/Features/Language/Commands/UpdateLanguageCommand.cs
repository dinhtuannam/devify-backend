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
                SqlLanguage lang = await _unitOfWork.LanguageRepository.updateLanguage(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(lang.code))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Update language failed",
                        data = "",
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Update language successfully",
                    data = "",
                    code = 200
                };  
            }
        }
    }
}
