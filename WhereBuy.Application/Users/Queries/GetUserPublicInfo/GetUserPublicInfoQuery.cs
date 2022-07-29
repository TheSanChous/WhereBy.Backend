using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereBuy.Application.Users.Queries.GetUserPublicInfo
{
    public class GetUserPublicInfoQuery : IRequest<UserPublicInfoVM>
    {
    }
}
