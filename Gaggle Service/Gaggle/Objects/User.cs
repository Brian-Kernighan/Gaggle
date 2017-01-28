using System;

namespace GaggleService.Gaggle.Objects
{
    public class User
    {
        User()
        {
        }

        public Guid Id { get; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public static User Create(string name, string email, string password)
        {
            return new User
            {
                Name = name,
                Email = email,
                Password = password
            };
        }
    }
}
