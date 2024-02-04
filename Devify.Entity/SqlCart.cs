using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("tb_carts")]
    public class SqlCart
    {
        [Key]
        public long id { get; set; }
        public double amount { get; set; } = 0;
        public double discount_price { get; set; } = 0;
        public double total { get; set; } = 0;
        public long userId { get; set; }
        public SqlUser? user { get; set; }
        public SqlDiscount? discount { get; set; }
        public List<SqlCourse>? courses { get; set; }
    }
}
