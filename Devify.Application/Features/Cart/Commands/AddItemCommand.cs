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
    public class AddItemCommand : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public string course { get; set; } = "";
        public AddItemCommand(string user, string course)
        {
            this.user = user;
            this.course = course;
        }
        public class Handler : IRequestHandler<AddItemCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(AddItemCommand query, CancellationToken cancellationToken)
            {
                CartItem cart = new CartItem();
                string result = await _unitOfWork.cart.addItem(query.user, query.course);
                if (!string.IsNullOrEmpty(result))
                {
                    return new ApiResponse(false, result, cart, 400);
                }
                cart = await _unitOfWork.cart.getCartDetail(query.user);
                return new ApiResponse(true, "Thêm sản phẩm thành công", cart, 200);
            }
        }
    }
}
