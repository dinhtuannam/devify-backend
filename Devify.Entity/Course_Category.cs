using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("Courses_Categories")]
    public class Course_Category
    {
        [ForeignKey("Course")]
        public Guid CourseId {  get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
