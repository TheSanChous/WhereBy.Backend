using System.Threading;
using System.Threading.Tasks;
using WhereBy.Domain;
using WhereBy.Auth.Models;
using WhereBy.Auth.Services;

namespace WhereBy.Auth
{
    public interface IAuthService
    {
        public Task<Tokens> LoginUserAsync(UserLoginModel loginModel, CancellationToken cancellationToken);
        public Task<Tokens> RegisterUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken);
    }
}
