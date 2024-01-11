using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Devify.Infrastructure.Services
{
    public class CategoryRepository : GenericRepository<SqlCategory>, ICategoryRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SqlCategory> createCategory(string code, string name, string des)
        {
            SqlCategory? cat = _unitOfWork.CategoryRepository.GetCode(code, 0).FirstOrDefault();
            if (cat != null)
            {
                return new SqlCategory();
            }
            SqlCategory m_cat = new SqlCategory()
            {
                id = DateTime.Now.Ticks,
                code = code,
                name = name,
                des = des,
                isdeleted = false
            };
            _unitOfWork.CategoryRepository.Insert(m_cat);
            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return new SqlCategory();
            }
            return m_cat;
        }

        public async Task<bool> deleteCategory(string code)
        {
            SqlCategory? cat = _unitOfWork.CategoryRepository.GetCode(code, 0).FirstOrDefault();
            if (cat == null)
            {
                return false;
            }

            cat.isdeleted = true;

            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return false;
            }
            return true;
        }

        public List<CategoryItem> getAllCategories()
        {
            List<CategoryItem> list = _unitOfWork.CategoryRepository.GetCondition(s => s.isdeleted == false)
                                                 .Select(s => new CategoryItem
                                                 {
                                                     code = s.code,
                                                     name = s.name,
                                                     des = s.des
                                                 })
                                                 .ToList();
            return list;
        }

        public CategoryItem getCategory(string code)
        {
            SqlCategory? cat = _unitOfWork.CategoryRepository.GetCondition(s => s.isdeleted == false && s.code.CompareTo(code) == 0).FirstOrDefault();
            if (cat == null)
            {
                return new CategoryItem();
            }
            CategoryItem item = new CategoryItem()
            {
                code = cat.code,
                name = cat.name,
                des = cat.des
            };
            return item;
        }

        public async Task<SqlCategory> updateCategory(string code, string name, string des)
        {
            SqlCategory? cat = _unitOfWork.CategoryRepository.GetCode(code, 0).FirstOrDefault();
            if (cat == null)
            {
                return new SqlCategory();
            }

            cat.name = name;
            cat.des = des;

            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return new SqlCategory();
            }
            return cat;
        }
    }
}
