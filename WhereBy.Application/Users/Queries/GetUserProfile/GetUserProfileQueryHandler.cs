using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhereBy.Application.Common.Exceptions;
using WhereBy.Application.Interfaces;

namespace WhereBy.Application.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileVM>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly ICurrentUserService currentUser;
        private readonly IMapper mapper;

        public GetUserProfileQueryHandler(IDatabaseContext databaseContext,
            ICurrentUserService currentUser,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.currentUser = currentUser;
            this.mapper = mapper;
        }

        public async Task<UserProfileVM> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(user => user.Id == currentUser.UserId);
            
            if(user == null)
            {
                throw new NotFoundException(nameof(user), currentUser.UserId);
            }

            return mapper.Map<UserProfileVM>(user);
        }
    }
}
