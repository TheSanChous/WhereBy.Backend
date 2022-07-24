using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhereBuy.Application.Users.Commands;
using WhereBuy.Application.Users.Queries.GetUserProfile;

namespace WhereBuy.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class AccountController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<UserProfileVM>> GetUserProfile()
        {
            return await Mediator.Send(new GetUserProfileQuery());
        }

        [HttpPost]
        public async Task<ActionResult<UserProfileVM>> UpdateUserProfile(UpdateUserProfileCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
