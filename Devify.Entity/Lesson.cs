using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("Lessons")]
    public class Lesson : TrackEntity
    {
        [Key]
        public Guid LessonId {  get; set; }
        public string Name { get; set;}
        public string? Description { get; set;}
        public string Status { get; set;}
        public string Video { get; set; }
        [ForeignKey("Chapter")]
        public Guid ChapterId { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
