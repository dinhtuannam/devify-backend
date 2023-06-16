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
        public string? Link { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }

        [ForeignKey("Creator")]
        public Guid CreatorId { get; set; }
        public virtual Creator Creator { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
        public virtual ICollection<Course_Language> CourseLanguages { get;} = new List<Course_Language>();
        public virtual ICollection<Course_Category> CourseCategories { get; } = new List<Course_Category>();
    }
}