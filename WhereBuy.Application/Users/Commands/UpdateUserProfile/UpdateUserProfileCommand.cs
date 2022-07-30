using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Application.Common.Mappings;
using WhereBuy.Application.Users.Queries.GetUserProfile;
using WhereBuy.Domain;

namespace WhereBuy.Application.Users.Commands
{
    public class UpdateUserProfileCommand : IRequest<UserProfileVM>
    {
        public string Name { get; set; }
    }
}
