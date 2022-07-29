using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WhereBuy.Application.Common.Exceptions;
using WhereBuy.Common.Abstractions;

namespace WhereBuy.Application.Users.Queries.GetUserPublicInfo
{
    public class GetUserPublicInfoQueryHandler : IRequestHandler<GetUserPublicInfoQuery, UserPublicInfoVM>
    {
        private readonly IDatabaseContext databaseContext;
        private readonly ICurrentUserService currentUser;
        private readonly IMapper mapper;

        public GetUserPublicInfoQueryHandler(IDatabaseContext databaseContext,
            ICurrentUserService currentUser,
            IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.currentUser = currentUser;
            this.mapper = mapper;
        }

        public async Task<UserPublicInfoVM> Handle(GetUserPublicInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(user => user.Id == currentUser.UserId);
            
            if(user == null)
            {
                throw new NotFoundException(nameof(user), currentUser.UserId);
            }

            return mapper.Map<UserPublicInfoVM>(user);
        }
    }
}
