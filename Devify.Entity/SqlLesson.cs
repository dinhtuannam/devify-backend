using Devify.Entity.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Devify.Entity
{
    [Table("tb_lessons")]
    public class SqlLesson : TrackEntity
    {
        [Key]
        public long id {  get; set; }
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public int step { get; set; } = 0;
        public string image { get; set; } = "";
        public string video { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public bool isactivated { get; set; } = false;
        public SqlChapter? chapter { get; set; }
        public SqlCourse? course { get; set; }
        public List<SqlComment>? comments { get; set; }

        public SqlLesson() : base() { }
    }
}
