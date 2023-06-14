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
        public virtual Course Course { get; set;}
        public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    }
}
