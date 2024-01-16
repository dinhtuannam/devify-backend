using Devify.Application.DTO;
using Devify.Application.Features.Language.Queries;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Category.Queries
{
    public class GetCategoryQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetCategoryQuery(string code)
        {
            this.code = code;
        }
        public class Handler : IRequestHandler<GetCategoryQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetCategoryQuery query, CancellationToken cancellationToken)
            {
                CategoryItem cat = _unitOfWork.category.getCategory(query.code);
                if (string.IsNullOrEmpty(cat.code))
                {
                    return Task.FromResult(new ApiResponse(false, "category not found", cat, 404));
                }
                return Task.FromResult(new ApiResponse(true, "get category successfully", cat, 200));
            }
        }
    }
}
