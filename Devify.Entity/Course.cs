using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("Courses")]
    public class Course : TrackEntity
    {
        [Key]
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public virtual IdentityUser Account { get; set; }
        public virtual ICollection<Chapter> Chapters { get; } = new List<Chapter>();
        public virtual ICollection<Course_Language> CourseLanguages { get; set; }
    }
}