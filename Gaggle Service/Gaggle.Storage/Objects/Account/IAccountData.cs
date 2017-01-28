using GaggleService.Gaggle.Common;
using GaggleService.Storage.Objects.Permission;
using System;
using System.Collections.Generic;

namespace GaggleService.Storage.Objects.Account
{
    public interface IAccountData
    {
        Guid Id { get; }
        string Name { get; }
        string Email { get; }
        string Password { get; }
        Authority Authority { get; }
        List<PermissionData> Permissions { get; }
    }
}
