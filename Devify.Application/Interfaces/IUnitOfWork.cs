namespace Devify.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository category { get; }
        ILanguageRepository language { get; }
        ICourseRepository course { get; }
        ITokenRepository token { get; }
        IUserRepository user { get; }
        ICacheRepository cache { get; }
        ILessonRepository lesson { get; }
        ICreatorRepository creator { get; }   
        ILevelRepository level { get; }
        IChapterRepository chapter { get; }
        IRoleRepository role { get; }
        IOrderRepository order { get; }
        ICartRepository cart { get; }
        IDiscountRepository discount { get; }
        IFirebaseRepository file { get; }
        Task<int> CompleteAsync();
    }
}
