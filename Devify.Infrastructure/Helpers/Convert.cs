using Devify.Infrastructure.Persistance;
using System.Globalization;
using System.Text;

namespace Devify.Infrastructure.Helpers
{
    public static class ConvertString
    {
        public static string NormalizeString(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            string result = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
            return result.ToLowerInvariant().Replace(" ", "");
        }

        public static string getSlug(string input)
        {
            string cleanedString = new string(input
               .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
               .ToArray());

            cleanedString = cleanedString.ToLowerInvariant();

            cleanedString = cleanedString.Replace(' ', '-');

            cleanedString = cleanedString + "-" + DataContext.randomString(6);
            return cleanedString;
        }
    }
}
