using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Claims;
using WhereBuy.Application.Interfaces;
using WhereBuy.Domain;

namespace WhereBuy.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration configuration;
        private readonly IDatabaseContext databaseContext;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, IDatabaseContext databaseContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
            this.databaseContext = databaseContext;
        }

        public int UserId
        {
            get
            {
                return GetUserIdFromHttpContext();
            }
        }

        public User User
        {
            get
            {
                return databaseContext.Users.FirstOrDefault(u => u.Id == UserId);
            }
        }

        private int GetUserIdFromHttpContext()
        {
            var userId = httpContextAccessor.HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) throw new UnauthorizedAccessException();
            return int.Parse(userId);
        }
    }
}
