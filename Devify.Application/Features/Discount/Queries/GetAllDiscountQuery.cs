using Devify.Application.DTO;
using Devify.Application.Features.Language.Queries;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Discount.Queries
{
    public class GetAllDiscountQuery : IRequest<ApiResponse>
    {
        public class Handler : IRequestHandler<GetAllDiscountQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public Task<ApiResponse> Handle(GetAllDiscountQuery query, CancellationToken cancellationToken)
            {
                ApiResponse res = new ApiResponse()
                {
                    result = true,
                    message = "Lấy danh sách mã giảm giá thành công",
                    code = 200,
                    data = _unitOfWork.discount.getAllDiscount()
                };
                return Task.FromResult(res);
            }
        }
    }
}
