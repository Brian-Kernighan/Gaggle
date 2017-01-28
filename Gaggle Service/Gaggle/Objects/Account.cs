using GaggleService.Gaggle.Common;
using System;
using System.Collections.Generic;

namespace GaggleService.Gaggle.Objects
{
    public class Account
    {
        Account()
        {
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Authority Authority { get; private set; }

        public List<Permission> Permissions { get; private set; }

        public static Account Create(Guid id, string name, string email, string password, Authority authority)
        {
            return new Account
            {
                Id = id,
                Name = name,
                Email = email,
                Password = password,
                Authority = authority
            };
        }
    }
}
