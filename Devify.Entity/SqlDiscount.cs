using Devify.Entity.Commons;
using Devify.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("tb_discounts")]
    public class SqlDiscount : TrackEntity
    {
        [Key]
        public long id { get; set; }
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public double value { get; set; } = 0;
        public DiscountEnum type { get; set; } = DiscountEnum.Price;
        public int quantity { get; set; } = 0;
        public double minimun { get; set; } = 0;
        public bool isDelete { get; set; } = false;
        public List<SqlOrder>? orders { get; set; }
        public DateTime expiredTime { get; set; }

        public SqlDiscount() : base() { }
    }
}
