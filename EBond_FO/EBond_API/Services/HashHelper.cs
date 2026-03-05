using System.Security.Cryptography;
using System.Text;

namespace EBond_API.Services
{
    public class HashHelper
    {
        public static string Hash(string input)
        {
            using var sha = SHA256.Create();

            var bytes = sha.ComputeHash(
                Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(bytes);
        }
    }
}
