
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Devify.Entity.Commons;

namespace Devify.Entity
{
    [Table("tb_courses")]
    public class SqlCourse : TrackEntity
    {
        [Key]
        public long id { get; set; }
        public string title { get; set; } = "";
        public long purchases { get; set; } = 0;
        public double price { get; set; } = 0;
        public double salePrice { get; set; } = 0;
        public string des { get; set; } = "";
        public string code { get; set; } = "";
        public string image { get; set; } = "";
        public bool isactivated { get; set; } = false;
        public bool isdeleted { get; set; } = false;
        public bool issale { get; set; } = false;
        public SqlUser? user { get; set; }
        public SqlCategory? category { get; set; }
        public List<SqlRating>? ratings { get; set; }
        public List<SqlLevel>? levels { get; set; }
        public List<SqlChapter>? chapters { get; set; }
        public List<SqlDetailOrder>? orders { get; set; }
        public List<SqlLanguage>? languages { get; set; }
        public SqlCourse() : base() { }

    }
}
