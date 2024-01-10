using Devify.Application.DTO;
using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Interfaces
{
    public interface ILevelRepository : IGenericRepository<SqlLevel>
    {
        public List<LevelItem> getAllLevel();
        public LevelItem getLevel(string code);
        public Task<SqlLevel> createLevel(string code, string name, string des);
        public Task<SqlLevel> updateLevel(string code, string name, string des);
        public Task<bool> deleteLevel(string code);
    }
}
