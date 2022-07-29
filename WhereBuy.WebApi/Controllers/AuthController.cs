using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Auth;
using WhereBuy.Auth.Models;
using WhereBuy.WebApi.Models;

namespace WhereBuy.WebApi.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<TokenResponse> Login(UserLoginModel loginModel, CancellationToken cancellationToken)
        {
            var tokens = await authService.LoginUserAsync(loginModel, cancellationToken);
            
            return new TokenResponse
            {
                Token = tokens.Token
            };
        }
        
        [HttpPost("register")]
        public async Task Register(UserRegisterModel registerModel, CancellationToken cancellationToken)
        {
            await authService.RegisterUserAsync(registerModel, cancellationToken);
        }

        [HttpPost("confirmEmail")]
        public async Task<TokenResponse> ConfirmEmail(EmailVereficationCodeModel codeModel, CancellationToken cancellationToken)
        {
            var tokens = await authService.ValidateVerificationCode(codeModel, cancellationToken);
            
            return new TokenResponse
            {
                Token = tokens.Token
            };
        }
    }
}
