
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
        [Required(ErrorMessage = "Trường name là bắt buộc.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái, số và khoảng trắng.")]
        [MaxLength(50, ErrorMessage = "Tên không được dài hơn 20 kí tự.")]
        public string Title { get; set; }
        public long Purchased { get; set; }
        public double Price { get; set; }
        [MaxLength(100, ErrorMessage = "Tên không được dài hơn 20 kí tự.")]
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public string? Image { get; set; }
        public string Status { get; set; }

        // ====================== Creator Foreign Key ==============================
        [ForeignKey("Creator")]
        public string CreatorId { get; set; }
        public Creator Creator { get; set; }

        // ====================== Category Foreign Key ==============================
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Category? Category { get; set; }

        // ====================== Level Foreign Key ==============================
        [ForeignKey("CourseLevel")]
        public string CourseLevelId { get; set; }
        public CourseLevel? CourseLevel { get; set; }

        // ====================== Collection Attributes ==============================
        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
        public ICollection<DetailOrder> DetailOrders { get; } = new List<DetailOrder>();
        public ICollection<Course_Language> CourseLanguages { get; } = new List<Course_Language>();
        
    }
}
