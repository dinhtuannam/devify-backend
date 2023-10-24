using Devify.Entity.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("Comments")]
    public class Comment : TrackEntity
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; } = "";
        public int? ParentId { get; set; } = 0;

        [ForeignKey("Lesson")]
        public Guid? LessonId { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
