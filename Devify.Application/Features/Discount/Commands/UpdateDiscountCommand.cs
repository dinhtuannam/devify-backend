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
    public class UpdateDiscountCommand : IRequest<ApiResponse>
    {
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public DiscountEnum type { get; set; } = DiscountEnum.Price;
        public int quantity { get; set; } = 0;
        public double minimum { get; set; } = 0;
        public string expiredTime { get; set; } = "";

        public UpdateDiscountCommand(string code, string name, string des, DiscountEnum type, int quantity, double minimum, string expiredTime)
        {
            this.code = code;
            this.name = name;
            this.des = des;
            this.type = type;
            this.quantity = quantity;
            this.minimum = minimum;
            this.expiredTime = expiredTime;
        }

        public class Handler : IRequestHandler<UpdateDiscountCommand, ApiResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ApiResponse> Handle(UpdateDiscountCommand query, CancellationToken cancellationToken)
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
                SqlDiscount result = await _unitOfWork.discount.updateDiscount(
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
                    return new ApiResponse(false, "Không tìm thấy mã giảm giá", discount, 404);
                }
                discount = _unitOfWork.discount.getDiscount(query.code);
                return new ApiResponse(true, "Cập nhật mã giảm giá thành công", discount, 200);
            }
        }
    }
