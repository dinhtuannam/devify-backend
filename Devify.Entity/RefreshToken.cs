using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Entity
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Account")]
        public string AccountId { get; set; }
        public  ApplicationUser Account { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime Expired { get; set; }
    }
}
