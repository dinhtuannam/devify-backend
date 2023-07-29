using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devify.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "RoleName is required.")]
        public string RoleName { get; set; }
    }
    public class RefreshToken_VM
    {
        public Guid Id { get; set; }
        public int AccountId { get; set; }
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

    public class RefreshToken_Request
    {
        [Required(ErrorMessage = "Token is required.")]
        public string refreshToken { get; set; }
    }
}
