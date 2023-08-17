using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Entity.Enums;
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
                var model = GetMulti(x=> x.CategoryName == name);
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
                var model = await _dbSet.Where(c => c.Status == CommonEnum.AVAILABLE)
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateUpdated
                }).ToListAsync();
                return model;
            }
            catch(Exception ex)
            {
                return new List<Category>();
            }
        }
    
    }
}
