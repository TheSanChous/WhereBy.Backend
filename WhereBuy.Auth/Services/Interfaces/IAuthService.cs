using WhereBuy.Auth.Models;

namespace WhereBuy.Auth
{
    public interface IAuthService
    {
        public Task<Tokens> LoginUserAsync(UserLoginModel loginModel, CancellationToken cancellationToken);
        public Task<Tokens> RegisterUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken);
    }
}
