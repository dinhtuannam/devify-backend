using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public int AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        //public Account Account { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime Expired { get; set; }
    }
}
