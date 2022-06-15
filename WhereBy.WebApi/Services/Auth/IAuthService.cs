using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Domain;
using WhereBuy.WebApi.Models.Auth;
using WhereBuy.WebApi.Services.JWT;

namespace WhereBuy.WebApi.Services.Auth
{
    public interface IAuthService
    {
        public Task<Tokens> LoginUserAsync(UserLoginModel loginModel, CancellationToken cancellationToken);
        public Task<Tokens> RegisterUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken);
    }
}
