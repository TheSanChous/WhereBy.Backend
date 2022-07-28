using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using WhereBy.Abstractions;
using WhereBy.Domain;

namespace WhereBy.Auth.Services
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

        public int? UserId => IsAuthenticated
            ? int.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
            : null;

        public User? User => IsAuthenticated
            ? databaseContext.Users.FirstOrDefault(u => u.Id == UserId)
            : null;

        public string? Email => IsAuthenticated
            ? httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
            : null;


        public int? Points => IsAuthenticated
            ? int.Parse(httpContextAccessor.HttpContext.User.FindFirstValue("Points"))
            : null;

        public bool IsAuthenticated => httpContextAccessor.HttpContext.User is not null;
    }
}
