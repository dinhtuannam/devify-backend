using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _DbContext = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> SearchAsAsync(string name)
        {
            try
            {
                var model = await _DbContext.Categories.Where(c => c.CategoryName == name).ToListAsync();
                return model;
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                var model = await _dbSet.Include(c=>c.Courses).ToListAsync();
                return model;
            }
            catch(Exception ex)
            {
                return new List<Category>();
            }
        }
    
    }
}
