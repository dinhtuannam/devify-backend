using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Devify.Infrastructure.Services
{
    public class DiscountRepository : GenericRepository<SqlDiscount>, IDiscountRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public DiscountRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SqlDiscount> addDiscount(string code, string name, string des, DiscountEnum type, int quantity, double minimum, DateTime expiredTime)
        {
            SqlDiscount? discount = _unitOfWork.discount.GetCondition(s => s.code.CompareTo(code) == 0 && s.isDelete == false).FirstOrDefault();
            if(discount != null)
            {
                return new SqlDiscount();
            }
            SqlDiscount newDiscount = new SqlDiscount()
            {
                id = DateTime.Now.Ticks,
                code = code,
                name = name,
                des = des,
                type = type,
                quantity = quantity,
                minimum = minimum,
                expiredTime = expiredTime,
            };
            _unitOfWork.discount.Insert(newDiscount);
            int rows = await _unitOfWork.CompleteAsync();
            return rows > 0 ? newDiscount : new SqlDiscount();
        }

        public async Task<bool> deleteDiscount(string code)
        {
            SqlDiscount? discount = _unitOfWork.discount.GetCondition(s => s.code.CompareTo(code) == 0 && s.isDelete == false).FirstOrDefault();
            if (discount == null)
            {
                return false;
            }
            _unitOfWork.discount.Delete(discount);
            int rows = await _unitOfWork.CompleteAsync();
            return rows > 0;
        }

        public List<DiscountItem> getAllDiscount()
        {
            List<DiscountItem> list = new List<DiscountItem>();
            List<SqlDiscount> discounts = _unitOfWork.discount.GetCondition(s => s.isDelete == false).ToList();
            
            foreach(SqlDiscount s in discounts)
            {
                DiscountItem item = new DiscountItem();
                item.code = s.code;
                item.name = s.name;
                item.des = s.des;
                item.type = s.type;
                item.quantity = s.quantity;
                item.minimum = s.minimum;
                item.expiredTime = s.expiredTime.ToString("dd-mm-yyyy hh:mm:ss");
                list.Add(item);
            }

            return list;
        }

        public DiscountItem getDiscount(string code)
        {
            DiscountItem item = new DiscountItem();
            SqlDiscount? discount = _unitOfWork.discount.GetCondition(s => s.code.CompareTo(code) == 0 && s.isDelete == false).FirstOrDefault();
            if(discount == null)
            {
                return item;
            }

            item.code = discount.code;
            item.name = discount.name;
            item.des = discount.des;
            item.type = discount.type;
            item.quantity = discount.quantity;
            item.minimum = discount.minimum;
            item.expiredTime = discount.expiredTime.ToString("dd-mm-yyyy hh:mm:ss");

            return item;
        }

        public async Task<SqlDiscount> updateDiscount(string code, string name, string des, DiscountEnum type, int quantity, double minimum, DateTime expiredTime)
        {
            SqlDiscount? discount = _unitOfWork.discount.GetCondition(s => s.code.CompareTo(code) == 0 && s.isDelete == false).FirstOrDefault();
            if (discount == null)
            {
                return new SqlDiscount();
            }
            discount.name = name;
            discount.des = des;
            discount.type = type;
            discount.quantity = quantity;
            discount.minimum = minimum;
            discount.expiredTime = expiredTime;
            discount.DateUpdated = DateTime.Now;

            _unitOfWork.discount.Update(discount);
            int rows = await _unitOfWork.CompleteAsync();
            return rows > 0 ? discount : new SqlDiscount();
        }
    }
}
