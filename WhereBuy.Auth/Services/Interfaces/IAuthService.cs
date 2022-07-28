using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Domain;
using WhereBuy.Auth.Models;
using WhereBuy.Auth.Services;

namespace WhereBuy.Auth
{
    public interface IAuthService
    {
        public Task<Tokens> LoginUserAsync(UserLoginModel loginModel, CancellationToken cancellationToken);
        public Task<Tokens> RegisterUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken);
    }
}
