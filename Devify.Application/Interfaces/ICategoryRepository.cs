using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<SqlCategory>
    {
        public CategoryItem getCategory(string code);
        public List<CategoryItem> getAllCategories();
        public Task<SqlCategory> createCategory(string code, string name, string des);
        public Task<SqlCategory> updateCategory(string code, string name, string des);
        public Task<bool> deleteCategory(string code);
    }
}
