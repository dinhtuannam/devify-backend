using Devify.Entity.Commons;
using Devify.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("Categories")]
    public class Category : TrackEntity
    {
        [Key]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public string? Description { get; set; } = "";
        public CommonEnum Status { get; set; } = CommonEnum.AVAILABLE;
        public  ICollection<Course>? Courses { get;  } = new List<Course>();
    }
}
