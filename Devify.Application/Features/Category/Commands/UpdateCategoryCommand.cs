using Devify.Application.DTO;
using Devify.Application.Features.Language.Commands;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;


namespace Devify.Application.Features.Category.Commands
{
    public class UpdateCategoryCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public UpdateCategoryCommand(string code, string name, string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }
        public class Handler : IRequestHandler<UpdateCategoryCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(UpdateCategoryCommand query, CancellationToken cancellationToken)
            {
                CategoryItem cat = _unitOfWork.category.getCategory(query.code);
                if (string.IsNullOrEmpty(cat.code))
                {
                    return new ApiResponse(false, "category not found", cat, 404);
                }
                SqlCategory result = await _unitOfWork.category.updateCategory(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(result.code))
                {
                    return new ApiResponse(false, "Update category failed", "", 400);
                }
                return new ApiResponse(true, "Update category successfully", result.code, 200);
            }
        }
    }
}
