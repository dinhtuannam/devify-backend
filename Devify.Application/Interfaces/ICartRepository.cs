using Devify.Application.DTO;
using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface ICartRepository : IGenericRepository<SqlCart>
    {
        public Task<string> addItem(string user, string course);
        public Task<string> removeItem(string user, string course);
        public Task<SqlCart> createCart(string user);
        public Task<SqlCart> getCart(string user);
        public Task<CartItem> getCartDetail(string user);
        public Task<string> applyDiscount(string user, string discount);
        public Task<string> removeDiscount(string user, string discount);
        public Task<bool> clearCart(string user);
    }
}
