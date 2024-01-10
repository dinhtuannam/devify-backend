using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.Services;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace Devify.Infrastructure.SeedWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly IDistributedCache _distributedCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public ICategoryRepository CategoryRepository { get; private set; }
        public ILanguageRepository LanguageRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }
        public IFirebaseRepository FirebaseRepository { get; private set; } 
        public IAuthRepository AuthRepository { get; private set; } 
        public ITokenRepository TokenRepository { get; private set; }
        public IAccountRepository AccountRepository { get; private set; }
        public ICacheRepository CacheRepository { get; private set; }
        public ILessonRepository LessonRepository { get; private set; }
        public ICreatorRepository CreatorRepository { get; private set; }
        public ILevelRepository LevelRepository { get; private set; }
        public IChapterRepository ChapterRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }

        public UnitOfWork(
            DataContext context,
            IDistributedCache distributedCache,
            IConnectionMultiplexer connectionMultiplexer )
        {
            _context = context;
            _distributedCache = distributedCache;
            _connectionMultiplexer = connectionMultiplexer;

            CategoryRepository = new CategoryRepository(_context,this);
            LanguageRepository = new LanguageRepository(_context,this);
            CourseRepository = new CourseRepository(_context, this);
            LessonRepository = new LessonRepository(_context,this);
            CreatorRepository = new CreatorRepository(_context,this);
            ChapterRepository = new ChapterRepository(_context, this);
            LevelRepository = new LevelRepository(_context, this);
            AuthRepository = new AuthRepository();
            TokenRepository = new TokenRepository(_context);
            AccountRepository = new AccountRepository(_context);
            CacheRepository = new CacheRepository(_distributedCache, _connectionMultiplexer);
            FirebaseRepository = new FirebaseRepository();
            RoleRepository = new RoleRepository(_context,this);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
