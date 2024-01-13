using Microsoft.Extensions.Configuration;
using System;

namespace Devify.Application.Configs
{
    public class ConfigKey
    {
        private readonly IConfiguration _configuration;
        public static Random random = new Random();
        public static string AT_COOKIES { get; set; } = "";
        public static string RT_COOKIES { get; set; } = "";
        public static string JWT_KEY { get; set; } = "";
        public static string VALID_AUDIENCE { get; set; } = "";
        public static string VALID_ISSUER { get; set; } = "";
        public static string CLOUD_NAME { get; set; } = "";
        public static string CLOUD_APIKEY { get; set; } = "";
        public static string CLOUD_APISECRET { get; set; } = "";
        public ConfigKey(IConfiguration configuration)
        {
            _configuration = configuration;
            AT_COOKIES = _configuration["JWT:AccessTokenCookies"];
            RT_COOKIES = _configuration["JWT:RefreshTokenCookies"];
            JWT_KEY = _configuration["JWT:Key"];
            VALID_AUDIENCE = _configuration["JWT:ValidAudience"];
            VALID_ISSUER = _configuration["JWT:ValidIssuer"];
            /*CLOUD_NAME = _configuration["Cloudinary:CloudName"];
            CLOUD_APIKEY = _configuration["Cloudinary:ApiKey"];
            CLOUD_APISECRET = _configuration["Cloudinary:ApiSecret"];*/
        }
        public static DateTime getATExpiredTime()
        {
            return DateTime.Now.AddMinutes(10);
        }

        public static DateTime getRTExpiredTime()
        {
            return DateTime.Now.AddHours(1);
        }

        public static string randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
