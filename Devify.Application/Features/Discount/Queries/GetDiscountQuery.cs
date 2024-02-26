using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Discount.Queries
{
    public class GetDiscountQuery : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public GetDiscountQuery(string code)
        {
            this.code = code;
        }
        public class Handler : IRequestHandler<GetDiscountQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetDiscountQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Lấy mã giảm giá thành công",
                    code = 200,
                    data = _unitOfWork.discount.getDiscount(query.code)
                };
                return Task.FromResult(res);
            }
        }
    }
}
