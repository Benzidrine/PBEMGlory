using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PBEMGlory.Accessors
{
    /// <summary>
    /// Class for accessing cryptographic functions
    /// </summary>
    public class CryptoAccessor
    {
        /// <summary>
        /// Takes in a password, salt and hash and compares them return true for a positive comparison
        /// </summary>
        public bool CheckHash(string password, string salt, string hash)
        {
            return (CreateHash(password, salt) == hash);
        }

        /// <summary>
        /// Create and return a salt as a string
        /// </summary>
        public string CreateSalt()
        {
            byte[] bytes = new byte[16];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// Create a hash of password
        /// </summary>
        public string CreateHash(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
}
