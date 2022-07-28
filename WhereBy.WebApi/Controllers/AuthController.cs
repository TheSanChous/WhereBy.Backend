using IdentityServer4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Auth;
using WhereBy.Auth.Models;
using WhereBy.Domain;
using WhereBy.WebApi.Models;

namespace WhereBy.WebApi.Controllers
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
        public async Task<TokenResponse> Register(UserRegisterModel registerModel, CancellationToken cancellationToken)
        {
            var tokens = await authService.RegisterUserAsync(registerModel, cancellationToken);
            return new TokenResponse
            {
                Token = tokens.Token
            };
        }
    }
}
