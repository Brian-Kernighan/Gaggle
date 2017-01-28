using GaggleService.Gaggle.Enums;
using System;

namespace GaggleService.Gaggle.Objects
{
    public class Permission
    {
        public Permission(PermissionType type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }

        public Guid Id { get; }

        public PermissionType Type { get; set; }
    }
}
