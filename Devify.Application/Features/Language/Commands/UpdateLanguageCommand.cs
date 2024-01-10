using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Language.Commands
{
    public class UpdateLanguageCommand : IRequest<ApiResponse>
    {
        public Entity.SqlLanguage updateLanguage { get; set; }
        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                /*var currentLanguage = _unitOfWork.LanguageRepository.GetByCondition(c => c.LanguageId == request.updateLanguage.LanguageId).FirstOrDefault();
                if (currentLanguage == null)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Language invalid",
                        ErrCode = "404",
                    };
                }
                currentLanguage.Name = request.updateLanguage.Name;
                currentLanguage.Status = request.updateLanguage.Status;
                currentLanguage.DateUpdated = DateTime.Now;
                var updateResult = _unitOfWork.LanguageRepository.UpdateEntity(currentLanguage);
                if (updateResult)
                {
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "Update language successfully",
                        ErrCode = "200",
                    };
                }*/
                return new ApiResponse
                {
                    Success = false,
                    Message = "Something wrong please try again",
                    ErrCode = "500",
                };

            }
        }
    }
}
