namespace Devify.Application.DTO
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class TokenInfoDecoded
    {
        public string Id { get; set; }
        public string RoleId { get; set;}
        public string Token { get; set; }
    }
}
