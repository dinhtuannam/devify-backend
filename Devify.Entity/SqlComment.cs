using Devify.Entity.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("tb_comments")]
    public class SqlComment : TrackEntity
    {
        [Key]
        public long id { get; set; }
        public string content { get; set; } = "";
        public long parent { get; set; } = 0;
        public bool isdeleted { get; set; } = false;
        public SqlLesson? lesson { get; set; }
        public SqlUser? user { get; set; }
        public SqlComment() : base() { }
    }
}
