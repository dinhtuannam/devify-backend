using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("tb_transactions")]
    public class SqlTransaction
    {
        [Key]
        public long id { get; set; }
        public string method { get; set; } = "";
        public DateTime time { get; set; }
        public double amount { get; set; } = 0;

    }
}
