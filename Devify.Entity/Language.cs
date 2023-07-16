using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Devify.Entity.Commons;

namespace Devify.Entity
{
    [Table("Languages")]
    public class Language : TrackEntity
    {
        [Key]
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public  ICollection<Course_Language> CourseLanguages { get; } = new List<Course_Language>();
    }
}
