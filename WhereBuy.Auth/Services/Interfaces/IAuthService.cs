using WhereBuy.Auth.Models;

namespace WhereBuy.Auth
{
    public interface IAuthService
    {
        public Task<Tokens> LoginUserAsync(UserLoginModel loginModel, CancellationToken cancellationToken);
        public Task RegisterUserAsync(UserRegisterModel registerModel, CancellationToken cancellationToken);
        public Task<Tokens> ValidateVerificationCode(EmailVereficationCodeModel codeModel, CancellationToken cancellationToken);
    }
}
