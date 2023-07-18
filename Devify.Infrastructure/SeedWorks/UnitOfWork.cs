using Castle.Core.Logging;
using Devify.Application.Interfaces;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.Services;

namespace Devify.Infrastructure.SeedWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository CategoryRepository { get; private set; }
        public ILanguageRepository LanguageRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            LanguageRepository = new LanguageRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
