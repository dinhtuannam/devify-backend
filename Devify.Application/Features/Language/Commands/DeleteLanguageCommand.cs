using Devify.Application.Commons;
using Devify.Application.Configs;
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
                LanguageItem exist = _unitOfWork.language.getLanguage(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "Language not found", false, 404);
                }
                bool lang = await _unitOfWork.language.DeleteLanguage(query.code);
                if (!lang)
                {
                    return new ApiResponse(false, "Delete language failed", false, 400);
                }

                await Task.WhenAll(
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.language),
                    _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.course)
                );
                
                return new ApiResponse(true, "Delete language successfully", true, 200);
            }
        }
    }
}
