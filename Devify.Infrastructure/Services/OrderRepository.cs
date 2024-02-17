using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;

namespace Devify.Infrastructure.Services
{
    public class OrderRepository : GenericRepository<SqlOrder>, IOrderRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;
        public OrderRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<bool> CheckOut(string user)
        {
            SqlOrder order = new SqlOrder();
            CartItem cart = await _unitOfWork.cart.getCartDetail(user);
            
            SqlUser buyer = _unitOfWork.user.GetRawEntityByCode(cart.user.code);
            if(user == null)
            {
                return false;
            }
            order.id = DateTime.Now.Ticks;
            order.des = "";
            order.user = buyer;
            order.price = cart.amount;
            order.sale = cart.discount_price;
            order.total = cart.total;

            if(cart.discount != null)
            {
                SqlDiscount? discount = _unitOfWork.discount.GetRawEntityByCode(cart.discount.code);
                if(discount != null)
                {
                    order.discount = discount;
                    discount.quantity = discount.quantity - 1;
                }
            }

            List<string> codes = cart.items.Select(s => s.code).ToList();
            List<SqlCourse> courses = _unitOfWork.course.GetContains(codes).ToList();

            foreach(SqlCourse s in courses)
            {
                SqlDetailOrder detail = new SqlDetailOrder();
                detail.id = DateTime.Now.Ticks;
                detail.order = order;
                detail.price = s.issale ? s.salePrice : s.price;
                detail.course = s;
                _context.detailOrders.Add(detail);
            }
            _unitOfWork.order.Insert(order);
            int rows = await _unitOfWork.CompleteAsync();
            await _unitOfWork.cart.clearCart(user);
            return rows >= codes.Count;
        }
    }
}
