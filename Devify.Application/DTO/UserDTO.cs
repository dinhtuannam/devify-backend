using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
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

    public class DetailAccountDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public Creator? Creator { get; set; }

        public ICollection<CourseOwnerDTO> Courses = new List<CourseOwnerDTO>();
    }

    public class CourseOwnerDTO
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
    }

    public class UserSignInInfo
    {
        public UserItem info { get; set; } = new UserItem();
        public TokenDTO token { get; set; } = new TokenDTO();   
    }
}
