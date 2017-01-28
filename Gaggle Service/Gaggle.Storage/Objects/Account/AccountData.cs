using GaggleService.Gaggle.Common;
using GaggleService.Storage.Objects.Permission;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GaggleService.Storage.Objects.Account
{
    public class AccountData : IAccountData
    {
        [BsonId]
        public Guid Id { get; internal set; }

        public string Name { get; internal set; }

        public string Email { get; internal set; }

        public string Password { get; internal set; }

        public Authority Authority { get; internal set; }

        public List<PermissionData> Permissions { get; internal set; }
    }
}