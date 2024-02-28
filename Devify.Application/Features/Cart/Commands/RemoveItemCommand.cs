using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Cart.Commands
{
    public class RemoveItemCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string course { get; set; } = "";
        public RemoveItemCommand(string user, string course)
        {
            this.user = user;
            this.course = course;
        }
        public class Handler : IRequestHandler<RemoveItemCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(RemoveItemCommand query, CancellationToken cancellationToken)
            {
                CartItem cart = new CartItem();
                string result = await _unitOfWork.cart.removeItem(query.user, query.course);
                if (!string.IsNullOrEmpty(result))
                {
                    return new ApiResponse(false, result, cart, 400);
                }
                cart = await _unitOfWork.cart.getCartDetail(query.user);
                await _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.cart);
                return new ApiResponse(true, "Xóa sản phẩm thành công", cart, 200);
            }
        }
    }
}
