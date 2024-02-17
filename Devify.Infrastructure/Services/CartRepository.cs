using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;


namespace Devify.Infrastructure.Services
{
    public class CartRepository : GenericRepository<SqlCart>, ICartRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> addItem(string user, string course)
        {
            SqlCart? cart = await getCart(user);
            if(cart == null)
            {
                cart = await createCart(user);
                if (cart == null)
                {
                    return "Lỗi khi tạo giỏ hàng mới";
                }
            }
            List<string> userBoughtList = _unitOfWork.course.GetListProductCodeBoughtByUser(user);
            string? bought = userBoughtList.Where(s => s.CompareTo(course) == 0).FirstOrDefault();
            if(bought != null)
            {
                return "Bạn hiện đã mua sản phẩm này";
            }
            SqlCourse? check = cart.courses != null ? 
                               cart.courses!.Where(s => s.code.CompareTo(course) == 0).FirstOrDefault() : null;
            if(check != null)
            {
                return "Sản phẩm đã tồn tại trong giỏ hàng";
            }
            SqlCourse? m_course = _unitOfWork.course.GetRawEntityByCode(course);
            if(m_course == null || m_course.isdeleted == true)
            {
                return "Không tìm thấy sản phẩm";
            }
            cart.courses!.Add(m_course);
            int row = await _unitOfWork.CompleteAsync();
            return row > 0 ? "" : "Vui lòng thử lại";
        }

        public async Task<string> applyDiscount(string user, string discount)
        {
            SqlCart? cart = await getCart(user);
            if (cart == null)
            {
                cart = await createCart(user);
                if (cart == null)
                {
                    return "Lỗi khi tạo giỏ hàng mới";
                }
                return "Vui lòng thêm sản phẩm";
            }
            if(cart.discount != null && cart.discount.code.CompareTo(discount.ToUpper()) == 0)
            {
                return "";
            }
            
            SqlDiscount? m_discount = _unitOfWork.discount.GetRawEntityByCode(discount.ToUpper());
            if (m_discount == null || m_discount.isDelete == true)
            {
                return "Không tìm thấy mã giảm giá";
            }
            double amount = cart.courses!.Count > 0 ? cart.courses!.Select(s => s.issale == true ? s.salePrice : s.price).Sum() : 0;
            DateTime now = DateTime.Now;
            if( m_discount.minimum > amount ||
                m_discount.isDelete == true ||
                m_discount.quantity <= 0 ||
                amount == 0 ||
                DateTime.Compare(m_discount.expiredTime, now) <= 0)
            {
                return "Không đủ điều kiện để dùng mã giảm giá";
            }
            cart.discount = m_discount;
            int row = await _unitOfWork.CompleteAsync();
            return row > 0 ? "" : "Vui lòng thử lại";
        }

        public async Task<bool> clearCart(string user)
        {
            SqlCart? cart = await getCart(user);
            if (cart == null)
            {
                return false;
            }
            cart.discount = null;
            cart.courses = null;
            int row = await _unitOfWork.CompleteAsync();
            return row > 0 ? true : false;
        }

        public async Task<SqlCart> createCart(string user)
        {
            SqlCart cart = new SqlCart();
            SqlUser? m_user = _unitOfWork.user.GetRawEntityByCode(user);
            if(m_user == null || m_user.isdeleted == true)
            {
                return cart;
            }
            cart.id = DateTime.Now.Ticks;
            cart.user = m_user;
            cart.courses = new List<SqlCourse>();
            _unitOfWork.cart.Insert(cart);
            int row = await _unitOfWork.CompleteAsync();
            return row > 0 ? cart : null;
        }

        public async Task<SqlCart> getCart(string user)
        {
            SqlCart? cart = _unitOfWork.cart.GetCondition(s => s.user != null && s.user.code.CompareTo(user) == 0)
                                            .Include(s => s.user)
                                            .Include(s => s.discount)
                                            .Include(s => s.courses)
                                            .FirstOrDefault();
            if(cart == null)
            {
                return null;
            }
            if(cart.user!.isdeleted == true)
            {
                _unitOfWork.cart.Delete(cart);
                await _unitOfWork.CompleteAsync();
                return null;
            }
            return cart;
        }

        public async Task<CartItem> getCartDetail(string user)
        {
            SqlCart? cart = await getCart(user);
            if(cart == null)
            {
                return new CartItem();
            }
            CartItem data = new CartItem();
            double discount_price = 0;

            if (cart.user != null){
                data.user.code = cart.user.code;
                data.user.displayName = cart.user.displayName;
                data.user.username = cart.user.username;
                data.user.image = cart.user.image;
            }

            foreach(SqlCourse course in cart.courses!)
            {
                if(course.isdeleted == false)
                {
                    ProductInCart item = new ProductInCart();
                    item.code = course.code;
                    item.title = course.title;
                    item.price = course.issale == true ? course.salePrice : course.price;
                    item.image = course.image;
                    item.createTime = course.DateCreated.ToString("dd-mm-yyyy hh:mm:ss");
                    item.updateTime = course.DateUpdated.ToString("dd-mm-yyyy hh:mm:ss");

                    data.items.Add(item);
                    data.amount = data.amount + item.price;
                }
            }

            if (cart.discount != null)
            {
                if(!validDiscount(cart,cart.discount,data.amount))
                {
                    cart.discount = null;
                    discount_price = 0;
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    data.discount.code = cart.discount.code;
                    data.discount.name = cart.discount.name;
                    data.discount.quantity = cart.discount.quantity;
                    data.discount.minimum = cart.discount.minimum;
                    data.discount.value = cart.discount.value;
                    data.discount.type = cart.discount.type;
                    data.discount.expiredTime = cart.discount.expiredTime.ToString("dd-mm-yyyy hh:mm:ss");
                    if(cart.discount.type == DiscountEnum.Price)
                    {
                        discount_price = cart.discount.value;
                    }
                    if (cart.discount.type == DiscountEnum.Percent)
                    {
                        double calc =  data.amount * cart.discount.value / 100;
                        discount_price = data.amount > calc ? calc : data.amount;
                    }
                }
            }

            data.amount = data.amount;
            data.discount_price = discount_price;
            data.total = data.amount - discount_price;

            return data;
        }

        public async Task<string> removeDiscount(string user, string discount)
        {
            SqlCart? cart = await getCart(user);
            if (cart == null)
            {
                cart = await createCart(user);
                if (cart == null)
                {
                    return "Lỗi khi tạo giỏ hàng mới";
                }
                return "Vui lòng thêm sản phẩm";
            }
            if (cart.discount == null || cart.discount.code.CompareTo(discount) != 0)
            {
                return "Không tìm thấy mã giảm giá";
            }
            cart.discount = null;
            int row = await _unitOfWork.CompleteAsync();
            return row > 0 ? "" : "Vui lòng thử lại";
        }

        public async Task<string> removeItem(string user, string course)
        {
            SqlCart? cart = await getCart(user);
            if (cart == null)
            {
                cart = await createCart(user);
                if (cart == null)
                {
                    return "Lỗi khi tạo giỏ hàng mới";
                }
                return "Vui lòng thêm sản phẩm";
            }
            if(cart.courses == null || cart.courses.Count  == 0)
            {
                return "Không tìm thấy sản phẩm";
            }
            SqlCourse? check = cart.courses.Where(s => s.code == course).FirstOrDefault();
            if (check == null)
            {
                return "Không tìm thấy sản phẩm";
            }
            cart.courses!.Remove(check);
            if(cart.discount != null)
            {
                double amount = cart.courses!.Count > 0 ? cart.courses!.Select(s => s.issale == true ? s.salePrice : s.price).Sum() : 0;
                if (!validDiscount(cart, cart.discount, amount))
                {
                    cart.discount = null;
                }
            }
            int row = await _unitOfWork.CompleteAsync();
            return row > 0 ? "" : "Vui lòng thử lại";
        }

        private bool validDiscount(SqlCart cart,SqlDiscount discount,double amount) 
        {
            DateTime now = DateTime.Now;
            if( cart.discount == null ||
                discount.minimum > amount ||
                discount.isDelete == true ||
                discount.quantity <= 0 ||
                amount == 0 ||
                DateTime.Compare(discount.expiredTime, now) <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
