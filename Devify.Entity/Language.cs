using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("Languages")]
    public class Language : TrackEntity
    {
        [Key]
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Course_Language> CourseLanguages { get; set; }
    }
}
