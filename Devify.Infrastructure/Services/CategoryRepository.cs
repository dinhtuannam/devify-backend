using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class CategoryRepository : GenericRepository<SqlCategory>, ICategoryRepository
    {
        private readonly DataContext _DbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _DbContext = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SqlCategory>> SearchAsAsync(string name)
        {
            try
            {
                /*var model = GetMulti(x=> x.CategoryName == name);
                return model;*/
                return null;
            }
            catch (Exception ex)
            {
                return new List<SqlCategory>();
            }
        }
    }
}
