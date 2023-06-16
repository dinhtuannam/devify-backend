using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("Creators")]
    public class Creator
    {
        [Key]
        public Guid CreatorId {  get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string? Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Course> Courses { get; } = new List<Course>();

    }
}
