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
    public class GetAllCategoryQuery : IRequest<ApiResponse>
    {
        public class Handler : IRequestHandler<GetAllCategoryQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetAllCategoryQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Get list category successfully",
                    code = 200,
                    data = _unitOfWork.category.getAllCategories()
                };
                return Task.FromResult(res);
            }
        }
    }
}
