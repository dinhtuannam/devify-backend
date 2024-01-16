using Devify.Application.Configs;
using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Helpers;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Devify.Infrastructure.Services
{
    public class UserRepository : GenericRepository<SqlUser>, IUserRepository  
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> banUser(string code)
        {
            SqlUser? user = _unitOfWork.user.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            user.isbanned = false;
            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return false;
            }
            return true;
        }

        public async Task<SqlUser> createUser(string username, string password, string displayName, string email, string role)
        {
            string code = ConvertString.getSlug(displayName);
            SqlUser? user = _unitOfWork.user.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false).FirstOrDefault();
            if(user != null)
            {
                return new SqlUser();
            }
            SqlRole? m_role = _unitOfWork.role.GetCode(code, -1).FirstOrDefault();
            if(m_role == null)
            {
                return new SqlUser();
            }
            SqlUser m_user = new SqlUser()
            {
                code = code,
                username = username,
                password = password,
                displayName = displayName,
                email = email,
                role = m_role
            };
            _unitOfWork.user.Insert(m_user);
            int row = await _unitOfWork.CompleteAsync();
            if(row <= 0)
            {
                return new SqlUser();
            }
            return m_user;
        }

        public async Task<bool> deleteUser(string code)
        {
            SqlUser? user = _unitOfWork.user.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false).FirstOrDefault();
            if(user == null)
            {
                return false;
            }
            user.isdeleted = true;
            int row = await _unitOfWork.CompleteAsync();
            if(row <= 0)
            {
                return false;
            }
            return true;
        }

        public async Task<SqlUser> editUser(string code, string username, string password, string displayName, string email, string image, string social, string about, string role)
        {
            SqlUser? user = _unitOfWork.user.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false).FirstOrDefault();
            if (user == null)
            {
                return new SqlUser();
            }
            SqlRole? m_role = _unitOfWork.role.GetCode(code, -1).FirstOrDefault();
            if (m_role == null)
            {
                return new SqlUser();
            }

            user.username = username;
            user.password = password;
            user.displayName = displayName;
            user.email = email;
            user.image = image;
            user.social = social;
            user.about = about;
            user.role = m_role;

            int row = await _unitOfWork.CompleteAsync();
            if (row <= 0)
            {
                return new SqlUser();
            }
            return user;
        }

        public List<UserItem> getListUser()
        {
            List<UserItem> list = _unitOfWork.user.GetAll().Where(s => s.isdeleted == false)
                                                  .Include(s => s.role)
                                                  .Select(s => new UserItem
                                                  {
                                                      code = s.code,
                                                      username = s.username,
                                                      email = s.email,
                                                      displayName = s.displayName,
                                                      image = s.image,
                                                      about = s.about,
                                                      social = s.social,
                                                      isbanned = s.isbanned,
                                                      role = s.role != null ? s.role.code : "",
                                                      createTime = s.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss"),
                                                      updateTime = s.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss")
                                                  })
                                                  .ToList();
            return list;
        }

        public UserItem getUser(string code)
        {
            SqlUser? user = _unitOfWork.user.GetCondition(s => s.code.CompareTo(code) == 0 && s.isdeleted == false)
                                            .Include(s => s.role).FirstOrDefault();
            if(user == null)
            {
                return new UserItem();
            }
            UserItem item = new UserItem
            {
                code = user.code,
                username = user.username,
                email = user.email,
                displayName = user.displayName,
                image = user.image,
                about = user.about,
                social = user.social,
                isbanned = user.isbanned,
                role = user.role != null ? user.role.code : "",
                createTime = user.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss"),
                updateTime = user.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss")
            };
            return item;
        }

        public UserItem getUserByName(string displayName)
        {
            SqlUser? user = _unitOfWork.user.GetCondition(s => s.displayName.CompareTo(displayName) == 0 && s.isdeleted == false)
                                            .Include(s => s.role).FirstOrDefault();
            if (user == null)
            {
                return new UserItem();
            }
            UserItem item = new UserItem
            {
                code = user.code,
                username = user.username,
                email = user.email,
                displayName = user.displayName,
                image = user.image,
                about = user.about,
                social = user.social,
                isbanned = user.isbanned,
                role = user.role != null ? user.role.code : "",
                createTime = user.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss"),
                updateTime = user.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss")
            };
            return item;
        }

        public UserItem getUserByUsername(string username)
        {
            SqlUser? user = _unitOfWork.user.GetCondition(s => s.displayName.CompareTo(username) == 0 && s.isdeleted == false)
                                            .Include(s => s.role).FirstOrDefault();
            if (user == null)
            {
                return new UserItem();
            }
            UserItem item = new UserItem
            {
                code = user.code,
                username = user.username,
                email = user.email,
                displayName = user.displayName,
                image = user.image,
                about = user.about,
                social = user.social,
                isbanned = user.isbanned,
                role = user.role != null ? user.role.code : "",
                createTime = user.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss"),
                updateTime = user.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss")
            };
            return item;
        }

        public UserItem signIn(string username, string password)
        {
            SqlUser? user = _unitOfWork.user.GetCondition(s => s.username.CompareTo(username) == 0 && s.password.CompareTo(password) == 0 && s.isdeleted == false)
                                            .Include(s => s.role)
                                            .FirstOrDefault();
            if(user == null)
            {
                return new UserItem();
            }
            UserItem item = new UserItem
            {
                code = user.code,
                username = user.username,
                email = user.email,
                displayName = user.displayName,
                image = user.image,
                about = user.about,
                social = user.social,
                isbanned = user.isbanned,
                role = user.role != null ? user.role.code : "",
                createTime = user.DateCreated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss"),
                updateTime = user.DateUpdated.ToUniversalTime().ToString("dd-mm-yyyy hh:mm:ss")
            };
            return item;

        }

    }
}
