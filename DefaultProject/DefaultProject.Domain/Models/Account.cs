using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace DefaultProject.Domain.Models
{
    public class Account : AuditableEntity
    {
        private readonly int SaltSize = 16;

        public Account() { }

        public Account(string email, string password)
        {
            Email = email;
            if (!string.IsNullOrEmpty(password))
            {
                Salt = CreateSalt();
                Password = GenerateHash(password);
            }
            AllowChangePassword = false;
        }

        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public bool AllowChangePassword { get; set; }

        private string CreateSalt()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] buff = new byte[SaltSize];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        private string GenerateHash(string plainTextInput)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(plainTextInput));

            argon2.Salt = Convert.FromBase64String(Salt);
            argon2.DegreeOfParallelism = 8;
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 128;

            return Convert.ToBase64String(argon2.GetBytes(16));
        }

    }
}
