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
        public ICategoryRepository category { get; private set; }
        public ILanguageRepository language { get; private set; }
        public ICourseRepository course { get; private set; }
        public IFirebaseRepository firebase { get; private set; } 
        public ITokenRepository token { get; private set; }
        public IUserRepository user { get; private set; }
        public ICacheRepository cache { get; private set; }
        public ILessonRepository lesson { get; private set; }
        public ICreatorRepository creator { get; private set; }
        public ILevelRepository level { get; private set; }
        public IChapterRepository chapter { get; private set; }
        public IRoleRepository role { get; private set; }
        public IOrderRepository order { get; private set; }
        public ICartRepository cart { get; private set; }
        public IDiscountRepository discount { get; private set; }

        public UnitOfWork(
            DataContext context,
            IDistributedCache distributedCache,
            IConnectionMultiplexer connectionMultiplexer )
        {
            _context = context;
            _distributedCache = distributedCache;
            _connectionMultiplexer = connectionMultiplexer;

            category = new CategoryRepository(_context,this);
            language = new LanguageRepository(_context,this);
            course = new CourseRepository(_context, this);
            lesson = new LessonRepository(_context,this);
            creator = new CreatorRepository(_context,this);
            chapter = new ChapterRepository(_context, this);
            level = new LevelRepository(_context, this);
            token = new TokenRepository(_context,this);
            user = new UserRepository(_context,this);
            cache = new CacheRepository(_distributedCache, _connectionMultiplexer);
            firebase = new FirebaseRepository();
            role = new RoleRepository(_context,this);
            order = new OrderRepository(_context, this);
            cart = new CartRepository(_context, this);
            discount = new DiscountRepository(_context, this);
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
