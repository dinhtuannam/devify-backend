using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;


namespace Devify.Application.Features.Cart.Commands
{
    public class ClearCartCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public ClearCartCommand(string user)
        {
            this.user = user;
        }
        public class Handler : IRequestHandler<ClearCartCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(ClearCartCommand query, CancellationToken cancellationToken)
            {
                CartItem cart = new CartItem();
                bool result = await _unitOfWork.cart.clearCart(query.user);
                if (!result)
                {
                    return new ApiResponse(false,"Dọn giỏ hàng thất bại", cart, 400);
                }
                cart = await _unitOfWork.cart.getCartDetail(query.user);
                return new ApiResponse(true, "Dọn giỏ hàng thành công", cart, 200);
            }
        }
    }
}
