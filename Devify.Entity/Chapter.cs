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
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public  Course Course { get; set;}
        public CommonEnum Status { get; set; }
        public  ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    }
}
