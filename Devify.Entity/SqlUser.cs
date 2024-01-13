using Devify.Entity.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("tb_users")]
    public class SqlUser : TrackEntity
    {
        public long id { get; set; }
        public string code { get; set; } = "";
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public string displayName { get; set; } = "";
        public string email { get; set; } = "";
        public string image { get; set; } = "";
        public bool isdeleted { get; set; } = false;
        public bool isbanned { get; set; } = false;
        public string about { get; set; } = "";
        public string social { get; set; } = "";
        public SqlRole? role { get; set; }
        public List<SqlOrder>? orders { get; } = new List<SqlOrder>();
        public List<SqlNotification>? notifications { get; } = new List<SqlNotification>();
        public List<SqlCourse>? courses { get; } = new List<SqlCourse>();
        public List<SqlToken>? tokens { get; } = new List<SqlToken>();
        public SqlUser() : base() { }
    }
}
