using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;


namespace Devify.Application.Features.Language.Commands
{
    public class CreateLanguageCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";

        public CreateLanguageCommand(string code, string name, string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }

        public class Handler : IRequestHandler<CreateLanguageCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(CreateLanguageCommand query, CancellationToken cancellationToken)
            {
                SqlLanguage lang = await _unitOfWork.language.createLanguage(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(lang.code))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Create language failed",
                        data = "",
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Create language successfully",
                    data = "",
                    code = 200
                };
            }
        }
    }
}
