using Devify.Application.DTO;
using Devify.Entity;


namespace Devify.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<SqlUser>
    {
        public UserItem getUser(string code);
        public UserItem getUserByName(string displayName);
        public UserItem getUserByUsername(string username);
        public List<UserItem> getListUser();
        public UserItem signIn(string username, string password);
        public Task<bool> deleteUser(string code);
        public Task<bool> banUser(string code);
        public Task<SqlUser> createUser(string username, string password, string displayName, string email,string role);
        public Task<SqlUser> editUser(string code, string username, string password, string displayName, string email, string image,string social,string about, string role);
    }
}
