using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MFF.DTO.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// get description of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (!(fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute), false) is DescriptionAttribute[] descriptionAttributes)) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Description : value.ToString();
        }

        /// <summary>
        /// get display name of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName<T>(T value)
        {
            return value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DisplayAttribute>(false)?
                .Name ??
                value.ToString();
        }

        /// <summary>
        /// get all description of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.GetTypeInfo().BaseType != typeof(Enum))
            {
                throw new ArgumentException("T is not System.Enum");
            }

            var enumValList = new List<KeyValuePair<int, string>>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new KeyValuePair<int, string>((int)e, (attributes.Length > 0) ? attributes[0].Description : e.ToString()));
            }

            return enumValList;
        }

        /// <summary>
        /// get all value and description of enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> GetEnumStringAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.GetTypeInfo().BaseType != typeof(Enum))
            {
                throw new ArgumentException("T is not System.Enum");
            }

            var enumValList = new List<KeyValuePair<string, string>>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new KeyValuePair<string, string>(e.ToString(), (attributes.Length > 0) ? attributes[0].Description : e.ToString()));
            }

            return enumValList;
        }
    }
}
