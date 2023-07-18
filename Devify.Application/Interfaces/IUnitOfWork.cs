namespace Devify.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        Task CompleteAsync();
    }
}
