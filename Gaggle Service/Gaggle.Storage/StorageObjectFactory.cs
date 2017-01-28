using GaggleService.Gaggle.Common;
using GaggleService.Gaggle.Objects;
using GaggleService.Storage.IObjects;
using GaggleService.Storage.Objects;
using System;
using System.Collections.Generic;

namespace GaggleService.Storage
{
    public class StorageObjectFactory
    {
        public static IAccountData Create(string name, string email, string password, Authority authority, List<PermissionData> permissions)
        {
            return new AccountData
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = password,
                Authority = authority,
                Permissions = permissions
            };
        }

        public static List<IPermissionData> Create(List<Permission> permissions)
        {
            throw new NotImplementedException();
        }
    }
}
