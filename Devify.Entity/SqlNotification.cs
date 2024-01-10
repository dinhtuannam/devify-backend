using Devify.Entity.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("tb_notifications")]
    public class SqlNotification : TrackEntity
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; } = "";
        public string content { get; set; } = "";
        public SqlUser? user { get; set; }
        public SqlNotification() : base() { }

    }
}
