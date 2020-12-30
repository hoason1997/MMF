using System.Text.RegularExpressions;

namespace  MFF.Infrastructure.Extensions
{
    public static class RegexReplaceExtension
    {
        public static string RegexReplace(this string oldString, string regex, string newString)
        {
            Regex regexObj = new Regex(regex);
            newString = regexObj.Replace(oldString, newString);
            return newString;
        }
    }
}
