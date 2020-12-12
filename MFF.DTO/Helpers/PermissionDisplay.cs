using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MFF.DTO.Helpers
{
    public class PermissionDisplay<T>
    {
        public PermissionDisplay(string groupName, string name, string description, T permission)
        {
            Permission = permission;
            PermissionName = permission.ToString();
            GroupName = groupName;
            ShortName = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string GroupName { get; private set; }

        public string ShortName { get; private set; }

        public string Description { get; private set; }

        public T Permission { get; private set; }
        public string PermissionName { get; private set; }

        public static List<PermissionDisplay<T>> GetPermissionsToDisplay(Type enumType)
        {
            var result = new List<PermissionDisplay<T>>();
            foreach (var permissionName in Enum.GetNames(enumType))
            {
                var member = enumType.GetMember(permissionName);
                var obsoleteAttribute = member[0].GetCustomAttribute<ObsoleteAttribute>();
                if (obsoleteAttribute != null)
                    continue;
                //If there is no DisplayAttribute then the Enum is not used
                var displayAttribute = member[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute == null)
                    continue;

                var permission = (T)Enum.Parse(enumType, permissionName, false);

                result.Add(new PermissionDisplay<T>(displayAttribute.GroupName, displayAttribute.Name,
                        displayAttribute.Description, permission));
            }

            return result;
        }
    }
}
