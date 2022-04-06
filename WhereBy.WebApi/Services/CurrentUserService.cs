using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WhereBy.Application.Interfaces;

namespace WhereBy.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        public int UserId
        {
            get
            {
                var id = _httpContextAccessor.HttpContext?.User?
                    .FindFirstValue(ClaimTypes.NameIdentifier);
                return string.IsNullOrEmpty(id) ? -1 : int.Parse(id);
            }
        }
    }
}
