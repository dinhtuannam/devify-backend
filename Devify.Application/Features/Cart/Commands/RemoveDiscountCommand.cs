using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Cart.Commands
{
    public class RemoveDiscountCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string discount { get; set; } = "";
        public RemoveDiscountCommand(string user, string discount)
        {
            this.user = user;
            this.discount = discount;
        }
        public class Handler : IRequestHandler<RemoveDiscountCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(RemoveDiscountCommand query, CancellationToken cancellationToken)
            {
                CartItem cart = new CartItem();
                string result = await _unitOfWork.cart.removeDiscount(query.user, query.discount);
                if (!string.IsNullOrEmpty(result))
                {
                    return new ApiResponse(false, result, cart, 400);
                }
                cart = await _unitOfWork.cart.getCartDetail(query.user);
                await _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.cart);
                return new ApiResponse(true, "Xóa thẻ giảm giá thành công", cart, 200);
            }
        }
    }
}
