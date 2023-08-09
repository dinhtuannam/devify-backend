using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace Devify.Infrastructure.SeedWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
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
        public ISliderRepository SliderRepository { get; private set; }
        public ICreatorRepository CreatorRepository { get; private set; }
        public UnitOfWork(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IDistributedCache distributedCache,
            IConnectionMultiplexer connectionMultiplexer )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _distributedCache = distributedCache;
            _connectionMultiplexer = connectionMultiplexer;

            CategoryRepository = new CategoryRepository(_context,this);
            LanguageRepository = new LanguageRepository(_context,this);
            CourseRepository = new CourseRepository(_context, this);
            LessonRepository = new LessonRepository(_context,this);
            CreatorRepository = new CreatorRepository(_context,this);
            SliderRepository = new SliderReposotory(_context,this);
            AuthRepository = new AuthRepository(_userManager , _signInManager);
            TokenRepository = new TokenRepository(_context, _userManager);
            AccountRepository = new AccountRepository(_userManager);
            CacheRepository = new CacheRepository(_distributedCache, _connectionMultiplexer);
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
