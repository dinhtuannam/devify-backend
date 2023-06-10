using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Models
{
    public class Auth_Model
    {
    }
    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class RefreshToken_VM
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
    public class Token_VM
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
