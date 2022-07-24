using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Application.Interfaces;
using WhereBuy.Application.Users.Queries.GetUserProfile;

namespace WhereBuy.Application.Users.Commands
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfileVM>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly ICurrentUserService currentUser;
        private readonly IMapper mapper;

        public UpdateUserProfileCommandHandler(IDatabaseContext databaseContext,
            ICurrentUserService currentUser,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.currentUser = currentUser;
            this.mapper = mapper;
        }

        public async Task<UserProfileVM> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(user => user.Id == currentUser.UserId, cancellationToken);

            user.Name = request.Name;

            await databaseContext.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserProfileVM>(user);
        }
    }
}
