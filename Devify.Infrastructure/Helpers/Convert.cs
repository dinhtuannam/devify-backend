using Devify.Infrastructure.Persistance;
using System.Globalization;
using System.Text;

namespace Devify.Infrastructure.Helpers
{
    public static class ConvertString
    {
        public static string convertToUnSign2(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

        public static string getSlug(string input)
        {
            input = convertToUnSign2(input);
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
