using Devify.Application.Commons;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Language.Commands
{
    public class DeleteLanguageCommand : IRequest<ApiResponse>
    {
        public string DeleteID { get; set; }
        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                /*var currentLanguage = _unitOfWork.LanguageRepository.GetByCondition(c => c.LanguageId == request.DeleteID).FirstOrDefault();
                if (currentLanguage == null)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Language invalid",
                        ErrCode = "404",
                    };
                }              
                var createResult = await _unitOfWork.LanguageRepository.DeleteAsAsync(currentLanguage);
                if (createResult)
                {
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "Delete language successfully",
                        ErrCode = "200",
                        Data = currentLanguage
                    };
                }
                else*/
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Delete language failed",
                        ErrCode = "500",
                    };

            }
        }
    }
}
