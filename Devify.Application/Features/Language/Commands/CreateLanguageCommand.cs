using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Language.Commands
{
    public class CreateLanguageCommand : IRequest<ApiResponse>
    {
        public Entity.SqlLanguage newLanguage {  get; set; }
        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateLanguageCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                /*request.newLanguage.LanguageId = AutoGenerate.GenerateID("lang",6);
                request.newLanguage.Status = "active";
                request.newLanguage.DateCreated = DateTime.Now;
                request.newLanguage.DateUpdated = DateTime.Now;
                var createResult = await _unitOfWork.LanguageRepository.AddAsAsync(request.newLanguage);
                if (createResult)
                {
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "Create new language successfully",
                        ErrCode = "200",
                        Data = request.newLanguage
                    };
                }
                else*/
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Create new language failed",
                        ErrCode = "500",
                    };

            }
        }
    }
}
