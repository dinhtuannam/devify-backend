using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("tb_detail_orders")]
    public class SqlDetailOrder
    {
        public long id { get; set; }
        public double price { get; set; } = 0;
        public SqlOrder? order { get; set; }
        public SqlCourse? course { get; set; }
    }
}
