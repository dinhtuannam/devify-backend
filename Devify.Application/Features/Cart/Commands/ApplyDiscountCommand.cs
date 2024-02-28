using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Features.Category.Queries;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Cart.Commands
{
    public class ApplyDiscountCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string discount { get; set; } = "";
        public ApplyDiscountCommand(string user,string discount)
        {
            this.user = user;
            this.discount = discount;
        }
        public class Handler : IRequestHandler<ApplyDiscountCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(ApplyDiscountCommand query, CancellationToken cancellationToken)
            {
                CartItem cart = new CartItem();
                string result = await _unitOfWork.cart.applyDiscount(query.user, query.discount);
                if (!string.IsNullOrEmpty(result)) {
                    return new ApiResponse(false, result, cart, 400);
                }
                cart = await _unitOfWork.cart.getCartDetail(query.user);
                await _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.cart);
                return new ApiResponse(true, "Áp dụng thẻ giảm giá thành công", cart, 200);
            }
        }
    }
}
