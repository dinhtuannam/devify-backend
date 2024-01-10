using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Devify.Entity.Commons;

namespace Devify.Entity
{
    [Table("tb_orders")]
    public class SqlOrder : TrackEntity
    {
        [Key]
        public long id { get; set; }
        public string des { get; set; } = "";
        public double price { get; set; } = 0;
        public double sale { get; set; } = 0;
        public double total { get; set; } = 0;
        public SqlDiscount? discount { get; set; }
        public SqlUser? user { get; set; }
        public List<SqlDetailOrder>? details { get; set; }
        public SqlOrder() : base() { }
    }
}
