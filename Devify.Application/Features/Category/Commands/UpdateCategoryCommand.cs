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
                SqlCategory cat = await _unitOfWork.category.updateCategory(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(cat.code))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Update category failed",
                        data = "",
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Update category successfully",
                    data = "",
                    code = 200
                };
            }
        }
    }
}
