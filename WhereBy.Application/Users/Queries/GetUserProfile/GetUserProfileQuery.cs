using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBy.Application.Users.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<UserProfileVM>
    {
    }
}
