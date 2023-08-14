using System.Text;

namespace Devify.Application.Commons
{
    public static class AutoGenerate
    {
        public static string GenerateRandomString(string s, int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            char[] randomChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }

            string randomString = new string(randomChars);

            return s + "-" + randomString;
        }

        public static string GenerateID(string type,int length = 8)
        {
            const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            StringBuilder idBuilder = new StringBuilder($"{type}-");

            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(0, characters.Length);
                idBuilder.Append(characters[randomIndex]);
            }

            return idBuilder.ToString();
        }
    }
}
