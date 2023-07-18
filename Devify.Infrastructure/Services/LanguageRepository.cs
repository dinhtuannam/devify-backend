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
        public LanguageRepository(ApplicationDbContext context) : base(context)
        {
            _DbContext = _context;
        }

        public override async Task<IEnumerable<Language>> GetAll()
        {
            try
            {
                var model = await _dbSet.ToListAsync();
                return model;
            }
            catch (Exception ex)
            {
                return new List<Language>();
            }
        }
    }
}
