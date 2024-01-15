using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using System.Xml.Linq;

namespace Devify.Infrastructure.Services
{
    public class RoleRepository : GenericRepository<SqlRole>, IRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SqlRole> createRole(string code, string name, string des)
        {
            SqlRole? role = _unitOfWork.role.GetCode(code, -1).FirstOrDefault();
            if(role != null)
            {
                return new SqlRole();
            }

            SqlRole m_role = new SqlRole();
            m_role.code = code;
            m_role.name = name;
            m_role.des = des;
            _unitOfWork.role.Insert(m_role);
            int row = await _unitOfWork.CompleteAsync();
            if(row <= 0)
            {
                return new SqlRole();
            }
            return m_role;
        }

        public async Task<bool> deleteRole(string code)
        {
            SqlRole? role = _unitOfWork.role.GetCode(code, -1).FirstOrDefault();
            if (role == null)
            {
                return false;
            }
            _unitOfWork.role.Delete(role);
            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return false;
            }
            return true;
        }

        public List<RoleItem> getListRole()
        {
            List<RoleItem> roles = _unitOfWork.role.GetAll().Select(s => new RoleItem
            {
                code = s.code,
                name = s.name,
                des = s.des
            }).ToList();

            return roles;
        }

        public RoleItem getRole(string code)
        {
            SqlRole? role = _unitOfWork.role.GetCode(code, -1).FirstOrDefault();
            if(role == null)
            {
                return new RoleItem();
            }
            return new RoleItem
            {
                code = role.code,
                name = role.name,
                des = role.des
            };
        }

        public async Task<SqlRole> updateRole(string code, string name, string des)
        {
            SqlRole? role = _unitOfWork.role.GetCode(code, -1).FirstOrDefault();
            if (role == null)
            {
                return new SqlRole();
            }

            role.code = code;
            role.name = name;
            role.des = des;

            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return new SqlRole();
            }
            return role;
        }
    }
}
