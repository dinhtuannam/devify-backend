namespace Devify.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        ICourseRepository CourseRepository { get; }
        IFirebaseRepository FirebaseRepository { get; }
        Task CompleteAsync();
    }
}
