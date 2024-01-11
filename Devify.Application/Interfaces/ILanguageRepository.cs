using Devify.Application.DTO;
using Devify.Entity;

namespace Devify.Application.Interfaces
{
    public interface ILanguageRepository : IGenericRepository<SqlLanguage>
    {
        public LanguageItem getLanguage(string code);
        public List<LanguageItem> getAllLanguages();
        public Task<SqlLanguage> createLanguage(string code, string name, string des);
        public Task<SqlLanguage> updateLanguage(string code, string name ,string des);
        public Task<bool> DeleteLanguage(string code);
    }
}
