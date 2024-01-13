using Devify.Application.DTO;
using Devify.Application.Features.Language.Commands;
using Devify.Application.Interfaces;
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
                bool res = await _unitOfWork.category.deleteCategory(query.code);
                if (!res)
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Delete category failed",
                        data = res,
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Delete category successfully",
                    data = res,
                    code = 200
                };
            }
        }
    }
}
