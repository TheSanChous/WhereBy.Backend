using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
