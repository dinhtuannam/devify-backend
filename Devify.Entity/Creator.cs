using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("Creators")]
    public class Creator
    {
        [ForeignKey("User")]
        public string CreatorId {  get; set; }
        public string Slug { get; set; }
        public string? FacebookUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public ApplicationUser User { get; set; }
        public  ICollection<Course> Courses { get; } = new List<Course>();

    }
}
