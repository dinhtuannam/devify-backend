using Devify.Entity.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Entity
{
    [Table("tb_chapters")]
    public class SqlChapter : TrackEntity
    {
        [Key]
        public long id { get; set; }
        public string code { get; set; } = "";
        public string name { get; set; } = "";
        public string des { get; set; } = "";
        public int step { get; set; } = 0;
        public bool isdeleted { get; set; } = false;
        public bool isactivated { get; set; } = false;
        public SqlCourse? course { get; set; }
        public List<SqlLesson>? lessons { get; set; }

        public SqlChapter() : base() { }

    }
}
