using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WhereBy.Application.Interfaces;
using WhereBy.Domain;

namespace WhereBy.WebApi.Services
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
            return int.Parse(httpContextAccessor.HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
