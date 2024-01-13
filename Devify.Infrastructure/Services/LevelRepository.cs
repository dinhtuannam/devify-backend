using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Devify.Infrastructure.Services
{
    public class LevelRepository : GenericRepository<SqlLevel>, ILevelRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public LevelRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;   
        }

        public async Task<SqlLevel> createLevel(string code, string name, string des)
        {
            SqlLevel? level = _unitOfWork.level.GetCode(code, -1).FirstOrDefault();
            if(level != null)
            {
                return new SqlLevel();
            }
            SqlLevel m_level = new SqlLevel();
            m_level.code = code;
            m_level.name = name;
            m_level.des = des;

            _unitOfWork.level.Insert(m_level);
            int row = await _unitOfWork.CompleteAsync();
            if(row <= 0)
            {
                return new SqlLevel();  
            }
            return m_level;
        }

        public async Task<bool> deleteLevel(string code)
        {
            SqlLevel? level = _unitOfWork.level.GetCode(code, -1).FirstOrDefault();
            if (level == null)
            {
                return false;
            }

            level.isdeleted = true;

            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return false;
            }
            return true;
        }

        public List<LevelItem> getAllLevel()
        {
            List<LevelItem> list = _unitOfWork.level.GetAll()
                                              .Where(s => s.isdeleted == false)
                                              .Select(s => new LevelItem
                                              {
                                                  code = s.code,
                                                  name = s.name,
                                                  des = s.des
                                              })
                                              .ToList();
            return list;
        }

        public LevelItem getLevel(string code)
        {
            SqlLevel? level = _unitOfWork.level.GetCode(code,0).FirstOrDefault();
            if(level == null)
            {
                return new LevelItem();
            }
            LevelItem item = new LevelItem()
            {
                code = level.code,
                name = level.name,
                des = level.des
            };
            return item;
        }

        public async Task<SqlLevel> updateLevel(string code, string name, string des)
        {
            SqlLevel? level = _unitOfWork.level.GetCode(code, 0).FirstOrDefault();
            if (level == null)
            {
                return new SqlLevel();
            }

            level.name = name;
            level.des = des;

            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return new SqlLevel();
            }
            return level;
        }
    }
}
