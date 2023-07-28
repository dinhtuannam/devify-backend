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
        public ICourseRepository CourseRepository { get; private set; }
        public IFirebaseRepository FirebaseRepository { get; private set; } 


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context,this);
            LanguageRepository = new LanguageRepository(_context,this);
            CourseRepository = new CourseRepository(_context, this);
            FirebaseRepository = new FirebaseRepository();
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
