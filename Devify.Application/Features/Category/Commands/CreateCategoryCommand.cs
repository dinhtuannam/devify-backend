using Devify.Application.Commons;
using Devify.Application.DTO;

using Devify.Application.Interfaces;

using MediatR;

namespace Devify.Application.Features.Category.Commands
{
    public class CreateCategoryCommand : IRequest<ApiResponse>
    {
        public Entity.SqlCategory newCategory { get; set; }
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                /*request.newCategory.CategoryId = AutoGenerate.GenerateID("cat");
                request.newCategory.Status = Entity.Enums.CommonEnum.AVAILABLE;
                request.newCategory.DateCreated = DateTime.Now;
                request.newCategory.DateUpdated = DateTime.Now;
                var createResult = await _unitOfWork.CategoryRepository.AddAsAsync(request.newCategory);
                if (createResult)
                {
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "Create new category successfully",
                        ErrCode = "200",
                        Data = request.newCategory
                    };
                }
                else*/
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Create new category failed",
                        ErrCode = "500",
                    };

            }
        }
    }
}
