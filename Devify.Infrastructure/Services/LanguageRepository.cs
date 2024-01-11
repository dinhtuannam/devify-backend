using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Devify.Infrastructure.Services
{
    public class LanguageRepository : GenericRepository<SqlLanguage>, ILanguageRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public LanguageRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SqlLanguage> createLanguage(string code, string name, string des)
        {
            SqlLanguage? lang = _unitOfWork.LanguageRepository.GetCode(code, 0).FirstOrDefault();
            if (lang != null)
            {
                return new SqlLanguage();
            }
            SqlLanguage m_lang = new SqlLanguage()
            {
                id = DateTime.Now.Ticks,
                code = code,
                name = name,
                des = des,
                isdeleted = false
            };
            _unitOfWork.LanguageRepository.Insert(m_lang);
            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return new SqlLanguage();
            }
            return m_lang;

        }

        public async Task<bool> DeleteLanguage(string code)
        {
            SqlLanguage? lang = _unitOfWork.LanguageRepository.GetCode(code, 0).FirstOrDefault();
            if (lang == null)
            {
                return false;
            }
            lang.isdeleted = true;
            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return false;
            }
            return true;
        }

        public List<LanguageItem> getAllLanguages()
        {
            List<LanguageItem> list = _unitOfWork.LanguageRepository.GetCondition(s => s.isdeleted == false)
                                                 .Select(s => new LanguageItem
                                                 {
                                                     code = s.code,
                                                     name = s.name,
                                                     des = s.des
                                                 })
                                                 .ToList();
            return list;
        }

        public LanguageItem getLanguage(string code)
        {
            SqlLanguage? lang = _unitOfWork.LanguageRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo(code) == 0).FirstOrDefault();
            if(lang == null)
            {
                return new LanguageItem();
            }
            LanguageItem item = new LanguageItem()
            {
                code = lang.code,
                name = lang.name,
                des = lang.des
            };
            return item;
        }

        public async Task<SqlLanguage> updateLanguage(string code, string name, string des)
        {
            SqlLanguage? lang = _unitOfWork.LanguageRepository.GetCode(code, 0).FirstOrDefault();
            if (lang == null)
            {
                return new SqlLanguage();
            }
            lang.name = name;
            lang.des = des;
            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return new SqlLanguage(); ;
            }
            return lang;
        }
    }
}
