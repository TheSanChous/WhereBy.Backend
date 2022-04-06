using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Domain;
using WhereBy.WebApi.Models.Auth;

namespace WhereBy.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class AuthController : BaseController
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IIdentityServerInteractionService identityServerInteractionService;

        public AuthController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            IIdentityServerInteractionService identityServerInteractionService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.identityServerInteractionService = identityServerInteractionService;
        }
    }
}
