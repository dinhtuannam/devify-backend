using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Features.Language.Commands;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;

namespace Devify.Application.Features.Category.Commands
{
    public class DeleteCategoryCommand : IRequest<ApiResponse>
    {
        public string code { get; set; }
        public DeleteCategoryCommand(string code)
        {
            this.code = code;
        }
        public class Handler : IRequestHandler<DeleteCategoryCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(DeleteCategoryCommand query, CancellationToken cancellationToken)
            {
                CategoryItem exist = _unitOfWork.category.getCategory(query.code);
                if (string.IsNullOrEmpty(exist.code))
                {
                    return new ApiResponse(false, "Category not found", false, 404);
                }
                bool cat = await _unitOfWork.category.deleteCategory(query.code);
                if (!cat)
                {
                    return new ApiResponse(false, "Delete category failed", false, 400);
                }
                await Task.WhenAll(
                   _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.category),
                   _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.course)
                );
                return new ApiResponse(true, "Delete category successfully", true, 200);
            }
        }
    }
}
