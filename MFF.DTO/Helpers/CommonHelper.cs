using System;

namespace MFF.DTO.Helpers
{
    public static class CommonHelper
    {
        public static string NewGuid()
        {
            var guid = Guid.NewGuid().ToString("N");
            return guid;
        }

        public static object GetPropValue<T>(string propName)
        {
            if (string.IsNullOrEmpty(propName))
                return null;

            try
            {
                return typeof(T).GetField(propName).GetValue(null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ToFullName(string firstName, string middleName, string lastName) => string.IsNullOrEmpty(middleName) ? $"{firstName} {lastName}" : $"{firstName} {middleName} {lastName}";
    }
}
