using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WhereBy.Application.Interfaces;

namespace WhereBy.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration configuration;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
        }

        public int UserId
        {
            get
            {
                return GetUserIdFromHttpContext();
            }
        }

        private int GetUserIdFromHttpContext()
        {
            return int.Parse(httpContextAccessor.HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
