using Devify.Application.DTO;
using Devify.Application.Features.Cart.Commands;
using Devify.Application.Interfaces;
using MediatR;

namespace Devify.Application.Features.Cart.Queries
{
    public class GetUserCartQuery : IRequest<ApiResponse>
    {
        public string user { get; set; } = "";
        public GetUserCartQuery(string user)
        {
            this.user = user;
        }
        public class Handler : IRequestHandler<GetUserCartQuery, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ApiResponse> Handle(GetUserCartQuery query, CancellationToken cancellationToken)
            {
                return new ApiResponse(true, "Lấy dữ liệu giỏ hàng thành công", await _unitOfWork.cart.getCartDetail(query.user), 200);
            }
        }
    }
}
