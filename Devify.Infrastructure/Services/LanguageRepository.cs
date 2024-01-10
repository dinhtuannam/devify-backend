using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Devify.Infrastructure.Services
{
    public class LanguageRepository : GenericRepository<SqlLanguage>, ILanguageRepository
    {
        private readonly DataContext _DbContext;
        private readonly IUnitOfWork _unitOfWork;
        public LanguageRepository(DataContext context,IUnitOfWork unitOfWork) : base(context)
        {
            _DbContext = _context;
            _unitOfWork = unitOfWork;
        }

        
    }
}
