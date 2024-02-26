using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity.Enums;
using Devify.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Features.Discount.Commands
{
    public class DeleteDiscountCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";

        public DeleteDiscountCommand(string code)
        {
            this.code = code;
        }

        public class Handler : IRequestHandler<DeleteDiscountCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(DeleteDiscountCommand query, CancellationToken cancellationToken)
            {
                DiscountItem discount = _unitOfWork.discount.getDiscount(query.code);
                if (string.IsNullOrEmpty(discount.code))
                {
                    return new ApiResponse(false, "Không tìm thấy mã giảm giá", false, 404);
                }
               
                bool result = await _unitOfWork.discount.deleteDiscount(query.code);
                if (!result)
                {
                    return new ApiResponse(false, "Xóa mã giảm giá thất bại", false, 400);
                }
                return new ApiResponse(true, "Xóa mã giảm giá thành công", true, 200);
            }
        }
    }
}
