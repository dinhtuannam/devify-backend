using Devify.Entity;

namespace Devify.Application
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
    }
}