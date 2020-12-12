using System.Text.RegularExpressions;

namespace  MFF.DTO.Helpers
{
    public static class AliasHelper
    {
        public static string GetFriendlyURL(string Title)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                string str = Title;
                for (int i = 1; i < VietNamChar.Length; i++)
                {
                    for (int j = 0; j < VietNamChar[i].Length; j++)
                        str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                }
                string pattern = @"/!|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.\.|\:|\;|\'|\""|\&|\#|\[|\]|-|~|$|_/";
                Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
                str = rg.Replace(str, " ");
                str = Regex.Replace(str, " {1,}", " ", RegexOptions.IgnoreCase);
                str = Regex.Replace(str.Trim(), " ", "-", RegexOptions.IgnoreCase);
                if (str.Length > 150)
                {
                    str = str.Remove(150);
                }
                return str.ToLower().Replace(".", "");
            }
            return "";
        }
        private static readonly string[] VietNamChar = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
       };
    }
}
