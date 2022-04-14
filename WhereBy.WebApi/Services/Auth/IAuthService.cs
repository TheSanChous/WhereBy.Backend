using System.Threading;
using System.Threading.Tasks;
using WhereBy.Domain;
using WhereBy.WebApi.Models.Auth;
using WhereBy.WebApi.Services.JWT;

namespace WhereBy.WebApi.Services.Auth
{
    public interface IAuthService
    {
        public Task<Tokens> LoginUserAsync(UserLoginModel loginModel, CancellationToken cancellationToken);
        public Task<Tokens> RegisterUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken);
    }
}
