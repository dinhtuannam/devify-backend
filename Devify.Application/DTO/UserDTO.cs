using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class UserProfile
    {
        public UserItem information { get; set; } = new UserItem();
        public List<CourseItem> courses { get; set; } = new List<CourseItem>();
    }

    public class UserItem
    {
        public string code { get; set; } = "";
        public string username { get; set; } = "";
        public string displayName { get; set; } = "";
        public string email { get; set; } = "";
        public string image { get; set; } = "";
        public string about { get; set; } = "";
        public string social { get; set; } = "";
        public string role { get; set; } = "";
        public bool isbanned { get; set; } = false;
        public string createTime { get; set; } = "";
        public string updateTime { get; set; } = "";
    }

    public class UserShortInfo
    {
        public string code { get; set; } = "";
        public string username { get; set; } = "";
        public string displayName { get; set; } = "";
        public string image { get; set; } = "";
    }

    public class UserSignInInfo
    {
        public UserItem info { get; set; } = new UserItem();
        public TokenDTO token { get; set; } = new TokenDTO();   
    }
}
