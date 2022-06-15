using IdentityServer4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Application.Common.Exceptions;
using WhereBuy.Domain;
using WhereBuy.WebApi.Models.Auth;
using WhereBuy.WebApi.Services.Auth;

namespace WhereBuy.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /login
        /// {
        ///     email: "user email",
        ///     password: "user password"
        /// }
        /// </remarks>
        /// <returns>Returns token (string)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Login(UserLoginModel loginModel, CancellationToken cancellationToken)
        {
            var tokens = await authService.LoginUserAsync(loginModel, cancellationToken);
            return tokens.Token;
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /register
        /// {
        ///     email: "user email",
        ///     password: "user password"
        /// }
        /// </remarks>
        /// <returns>Returns token (string)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Register(UserRegisterModel registerModel, CancellationToken cancellationToken)
        {
            var tokens = await authService.RegisterUserAsync(registerModel, cancellationToken);
            return tokens.Token;
        }
    }
}
