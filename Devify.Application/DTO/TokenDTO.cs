namespace Devify.Application.DTO
{
    public class TokenDTO
    {
        public string AccessToken { get; set; } = "";
        public string RefreshToken { get; set; } = "";
    }

    public class TokenDecodedInfo
    {
        public string code { get; set; } = "";
        public string username { get; set; } = "";
        public string role { get; set; } = "";
    }
}
