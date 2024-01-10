using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Devify.Entity.Commons;

namespace Devify.Entity
{
    [Table("tb_languages")]
    public class SqlLanguage
    {
        [Key]
        public long id { get; set; }
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public  List<SqlCourse>? courses { get; set; }
    }
}
