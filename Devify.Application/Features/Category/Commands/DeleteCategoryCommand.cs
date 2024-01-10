using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Category.Commands
{
    public class DeleteCategoryCommand : IRequest<ApiResponse>
    {
        public string DeleteID { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                /*var currentCategory = _unitOfWork.CategoryRepository.GetByCondition(c => c.CategoryId == request.DeleteID).FirstOrDefault();
                if (currentCategory == null)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "category invalid",
                        ErrCode = "404",
                    };
                }
                var createResult = await _unitOfWork.CategoryRepository.DeleteAsAsync(currentCategory);
                if (createResult)
                {
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "Delete category successfully",
                        ErrCode = "200",
                        Data = currentCategory
                    };
                }
                else*/
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Delete category failed",
                        ErrCode = "500",
                    };

            }
        }
    }
}
