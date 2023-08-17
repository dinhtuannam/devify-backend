using Devify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class Account_Information_DTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }

    public class DetailAccountDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Creator? Creator { get; set; }

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
}
