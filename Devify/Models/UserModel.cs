namespace Devify.Models
{
    public class CreateUserModel
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public string displayName { get; set; } = "";
        public string email { get; set; } = "";
        public string role { get; set; } = "";
    }

    public class UpdateUserModel
    {
        public string code { get; set; } = "";
        public string username { get; set; } = "";
        public string displayName { get; set; } = "";
        public string email { get; set; } = "";
        public string social { get; set; } = "";
        public string about { get; set; } = "";
        public string role { get; set; } = "";
    }

    public class SignInModel
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }

    public class UpdatePasswordModel
    {
        public string code { get; set; } = "";
        public string curPassword { get; set; } = "";
        public string newPassword { get; set; } = "";
    }
}
