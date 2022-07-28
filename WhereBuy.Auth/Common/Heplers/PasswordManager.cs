using System.Security.Cryptography;
using System.Text;

namespace WhereBuy.Auth.Common.Helpers
{
    public static class PasswordManager
    {
        public static async Task<string> GetPasswordHashAsync(string password)
        {
            var hash = await SHA256.Create()
                .ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(password)));
            return Encoding.UTF8.GetString(hash);
        }
    }
}
