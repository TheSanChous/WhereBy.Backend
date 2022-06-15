﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WhereBuy.Application.Common.Exceptions;
using WhereBuy.Application.Interfaces;

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
