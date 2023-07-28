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
    }
}
