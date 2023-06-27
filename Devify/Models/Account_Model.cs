namespace Devify.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Salt { get; set; }

        public bool Active { get; set; }

        public string? Fullname { get; set; }

        public int? RoleId { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime? CreateDate { get; set; }
    }

    public class Account_Information_VM
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
