using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WhereBuy.Auth.Common.Exceptions;
using WhereBuy.Common.Abstractions;

namespace WhereBuy.WebApi.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute
    {
        private readonly ICurrentUserService currentUserService;

        public AuthorizeAttribute(ICurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (currentUserService.UserId < 0)
            {
                throw new UnauthorizedException();
            }
        }
    }
}
