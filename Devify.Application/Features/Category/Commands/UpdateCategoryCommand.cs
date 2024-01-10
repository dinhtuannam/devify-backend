using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Category.Commands
{
    public class UpdateCategoryCommand : IRequest<ApiResponse>
    {
        public Entity.SqlCategory newCategory { get; set; }
        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                /*var currentCategory = _unitOfWork.CategoryRepository.GetByCondition(c => c.CategoryId == request.newCategory.CategoryId).FirstOrDefault();
                if(currentCategory == null)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Category invalid",
                        ErrCode = "404",
                    };
                }
                currentCategory.CategoryName = request.newCategory.CategoryName;
                currentCategory.Description = request.newCategory.Description;
                currentCategory.Status = request.newCategory.Status;
                currentCategory.DateUpdated = DateTime.Now;
                var updateResult =  _unitOfWork.CategoryRepository.UpdateEntity(currentCategory);
                if (updateResult)
                {
                    await _unitOfWork.CompleteAsync();
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "Update category successfully",
                        ErrCode = "200",                  
                    };
                }*/
                return new ApiResponse
                {
                    result = false,
                    message = "Something wrong please try again",
                    code = 500,
                };

            }
        }
    }
}
