using Devify.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("tb_files")]
    public class SqlFile
    {
        [Key]
        public long id { get; set; }
        public string path { get; set; } = "";
        public string fileName { get; set; } = "";
        public FileEnum type { get; set; }
        public DateTime time { get; set; }
    }
}
