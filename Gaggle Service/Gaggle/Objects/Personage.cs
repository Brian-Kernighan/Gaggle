using System;

namespace GaggleService.Gaggle.Objects
{
    public class Personage
    {
        Personage()
        {
        }

        public Guid Id { get; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public static Personage Create(string name, string email, string password)
        {
            return new Personage
            {
                Name = name,
                Email = email,
                Password = password
            };
        }
    }
}
