using Devify.Application.Commons;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;


namespace Devify.Application.Features.Language.Commands
{
    public class DeleteLanguageCommand : IRequest<ApiResponse>
    {
        public string code { get; set; }
        public DeleteLanguageCommand(string code)
        {
            this.code = code;
        }
        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(DeleteLanguageCommand query, CancellationToken cancellationToken)
            {
                bool res = await _unitOfWork.language.DeleteLanguage(query.code);
                if (!res)
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Delete language failed",
                        data = res,
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Delete language successfully",
                    data = res,
                    code = 200
                };
            }
        }
    }
}
