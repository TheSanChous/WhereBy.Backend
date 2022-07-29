using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhereBuy.Application.Users.Commands;
using WhereBuy.Application.Users.Queries.GetUserProfile;

namespace WhereBuy.WebApi.Controllers
{
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
