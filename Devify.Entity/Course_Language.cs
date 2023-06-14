using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("Course_Languages")]
    public class Course_Language
    {     
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Language")]
        public string LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
