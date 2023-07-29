namespace Devify.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        ICourseRepository CourseRepository { get; }
        IFirebaseRepository FirebaseRepository { get; }
        IAuthRepository AuthRepository { get; }
        ITokenRepository TokenRepository { get; }
        IAccountRepository AccountRepository { get; }
        ICacheRepository CacheRepository { get; }
        Task CompleteAsync();
    }
}
