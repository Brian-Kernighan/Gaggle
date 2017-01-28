using GaggleService.Gaggle.Enums;
using GaggleService.Gaggle.Objects;
using System.Collections.Generic;

namespace GaggleService.Gaggle.Common
{
    public static class DefaultPermissions
    {
        public static List<Permission> GagglePermission = new List<Permission>
        {
            new Permission(PermissionType.AccountRead),
            new Permission(PermissionType.AccountCreate),
            new Permission(PermissionType.AccountDelete),
            new Permission(PermissionType.AccountUpdate),
        };

        public static List<Permission> DefaultPermission = new List<Permission>
        {
            new Permission(PermissionType.PersonageRead),
            new Permission(PermissionType.PersonageCreate),
            new Permission(PermissionType.PersonageDelete),
            new Permission(PermissionType.PersonageUpdate),
        };
    }
}
