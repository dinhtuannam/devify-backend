using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("Categories")]
    public class Category : TrackEntity
    {
        [Key]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Course_Category> CourseCategories { get;  } = new List<Course_Category>();
    }
}
