using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    [Table("tb_token")]
    public class SqlToken
    {
        [Key]
        public long id { get; set; }
        public string accessToken { get; set; } = "";
        public string refreshToken { get; set; } = "";
        public DateTime createTime { get; set; }
        public DateTime expiredTime { get; set; }
        public bool isExpired { get; set; } = false;
        public SqlUser? user { get; set; }
    }
}
