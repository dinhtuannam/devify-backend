using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Features.Language.Commands;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Devify.Application.Features.Discount.Commands
{
    public class CreateDiscountCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public DiscountEnum type { get; set; } = DiscountEnum.Price;
        public int quantity { get; set; } = 0;
        public double minimum { get; set; } = 0;
        public string expiredTime { get; set; } = "";

        public CreateDiscountCommand(string code, string name, string des,DiscountEnum type,int quantity, double minimum,string expiredTime)
        {
            this.code = code;
            this.name = name;
            this.des = des;
            this.type = type;
            this.quantity = quantity;
            this.minimum = minimum;
            this.expiredTime = expiredTime;
        }

        public class Handler : IRequestHandler<CreateDiscountCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(CreateDiscountCommand query, CancellationToken cancellationToken)
            {
                DiscountItem discount = new DiscountItem();
                DateTime m_expiredTime = DateTime.MinValue;
                try
                {
                    m_expiredTime = DateTime.ParseExact(query.expiredTime, "dd-MM-yyyy", null);
                }
                catch (Exception e)
                {
                    return new ApiResponse(false, "Thời gian không hợp lệ", discount, 400);
                }
                SqlDiscount result = await _unitOfWork.discount.addDiscount(
                    query.code,
                    query.name,
                    query.des,
                    query.type,
                    query.quantity,
                    query.minimum,
                    m_expiredTime
                );
                if (string.IsNullOrEmpty(result.code))
                {
                    return new ApiResponse(false, "Code của mã giảm giá đã tồn tại", discount, 400);
                }
                discount = _unitOfWork.discount.getDiscount(query.code);
                if (string.IsNullOrEmpty(discount.code))
                {
                    return new ApiResponse(false, "Không tìm thấy mã giảm giá", discount, 404);
                }
                await _unitOfWork.cache.RemoveCacheResponseAsync(ApiRoutes.discount);
                return new ApiResponse(true, "Tạo mã giảm giá thành công", discount, 200);
            }
        }
    }
}
