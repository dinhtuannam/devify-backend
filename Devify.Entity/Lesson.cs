using Devify.Entity.Commons;
using Devify.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("Lessons")]
    public class Lesson : TrackEntity
    {
        [Key]
        public Guid LessonId {  get; set; }
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public int? Step { get; set; } = 0;
        public string? Image { get; set; } = "";
        public string? Video { get; set; } = "";
        [ForeignKey("Chapter")]
        public Guid? ChapterId { get; set; }
        public  Chapter? Chapter { get; set; }
        public LessonEnum Status { get; set; } = LessonEnum.AVAILABLE;
        public ICollection<Comment>? Comments { get; } = new List<Comment>();
    }
}
