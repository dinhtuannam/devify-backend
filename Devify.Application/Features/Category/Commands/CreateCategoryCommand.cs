using Devify.Application.Commons;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using MediatR;

namespace Devify.Application.Features.Category.Commands
{
    public class CreateCategoryCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";

        public CreateCategoryCommand(string code, string name, string des)
        {
            this.code = code;
            this.name = name;
            this.des = des;
        }

        public class Handler : IRequestHandler<CreateCategoryCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(CreateCategoryCommand query, CancellationToken cancellationToken)
            {
                SqlCategory cat = await _unitOfWork.CategoryRepository.createCategory(query.code, query.name, query.des);
                if (string.IsNullOrEmpty(cat.code))
                {
                    return new ApiResponse()
                    {
                        result = false,
                        message = "Create category failed",
                        data = "",
                        code = 400
                    };
                }
                return new ApiResponse()
                {
                    result = true,
                    message = "Create category successfully",
                    data = "",
                    code = 200
                };
            }
        }
    }
}
