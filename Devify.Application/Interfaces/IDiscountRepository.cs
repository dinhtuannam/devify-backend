using Devify.Application.DTO;
using Devify.Entity;
using Devify.Entity.Enums;

namespace Devify.Application.Interfaces
{
    public interface IDiscountRepository : IGenericRepository<SqlDiscount>
    {
        public List<DiscountItem> getAllDiscount();
        public DiscountItem getDiscount(string code);
        public Task<SqlDiscount> addDiscount(string code, string name, string des, DiscountEnum type, int quantity, double minimum, DateTime expiredTime);
        public Task<SqlDiscount> updateDiscount(string code, string name, string des, DiscountEnum type, int quantity, double minimum, DateTime expiredTime);
        public Task<bool> deleteDiscount(string code);
    }
}
