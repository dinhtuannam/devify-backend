using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Application.DTO
{
    public class DetailCreatorDTO
    {
        public string CreatorId { get; set; }
        public string Slug { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string PhoneNumber { get; set; }
    }

    public class DetailCreatorPublicDTO
    {
        public string CreatorId { get; set; }
        public string Slug { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }    
    }

    public class CreatorCoursesDTO
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Slug { get; set; }
        public string Image { get; set; }
    }

}
