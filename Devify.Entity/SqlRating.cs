using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("tb_ratings")]
    public class SqlRating
    {
        [Key]
        public long id { get; set; }
        public int point { get; set; } = 0;
        public bool isDelete { get; set; } = false;
        public SqlUser? user { get; set; }
        public SqlCourse? course { get; set; }
    }
}
