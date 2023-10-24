
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Devify.Entity.Commons;

namespace Devify.Entity
{
    [Table("Courses")]
    public class Course : TrackEntity
    {
        [Key]
        public Guid CourseId { get; set; }
        public string Title { get; set; } = "";
        public long Purchased { get; set; } = 0;
        public double Price { get; set; } = 0;
        public string? Description { get; set; } = "";
        public string? Slug { get; set; } = "";
        public string? Image { get; set; } = "";
        public string Status { get; set; } = "active";

        // ====================== Creator Foreign Key ==============================
        [ForeignKey("Creator")]
        public string? CreatorId { get; set; }
        public Creator? Creator { get; set; }

        // ====================== Category Foreign Key ==============================
        [ForeignKey("Category")]
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }

        // ====================== Level Foreign Key ==============================
        [ForeignKey("CourseLevel")]
        public string? CourseLevelId { get; set; }
        public CourseLevel? CourseLevel { get; set; }

        // ====================== Collection Attributes ==============================
        public ICollection<Chapter>? Chapters { get; set; } = new List<Chapter>();
        public ICollection<DetailOrder>? DetailOrders { get; } = new List<DetailOrder>();
        public ICollection<Course_Language>? CourseLanguages { get; } = new List<Course_Language>();
        
    }
}
