using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IUnitOfWork _unitOfWork;
        public LanguageRepository(ApplicationDbContext context,IUnitOfWork unitOfWork) : base(context)
        {
            _DbContext = _context;
            _unitOfWork = unitOfWork;
        }

        public override async Task<IEnumerable<Language>> GetAllAsync()
        {
            try
            {
                var model = await _dbSet.Where(ln => ln.Status == "active")
                .Select(ln => new Language
                {
                    LanguageId = ln.LanguageId,
                    Name = ln.Name,
                    DateCreated = ln.DateCreated,
                    DateUpdated = ln.DateUpdated,
                }).ToListAsync();
                return model;
            }
            catch (Exception ex)
            {
                return new List<Language>();
            }
        }
    }
}
