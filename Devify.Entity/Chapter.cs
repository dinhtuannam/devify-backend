using Devify.Entity.Commons;
using Devify.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("Chapters")]
    public class Chapter : TrackEntity
    {
        [Key]
        public Guid ChapterId { get; set; }

        [Required(ErrorMessage = "Trường name là bắt buộc.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái, số và khoảng trắng.")]
        [MaxLength(50, ErrorMessage = "Tên không được dài hơn 50 kí tự.")]
        public string Name { get; set; }
        [Required]
        public int? Step { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public  Course Course { get; set;}
        public CommonEnum Status { get; set; }
        public  ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    }
}
