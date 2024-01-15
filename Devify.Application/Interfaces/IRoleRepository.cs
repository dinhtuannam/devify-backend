using Devify.Application.DTO;
using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.Interfaces
{
    public interface IRoleRepository : IGenericRepository<SqlRole>
    {
        public List<RoleItem> getListRole();
        public RoleItem getRole(string code);
        public Task<SqlRole> createRole(string code, string name, string des);
        public Task<SqlRole> updateRole(string code, string name, string des);
        public Task<bool> deleteRole(string code);
    }
}
