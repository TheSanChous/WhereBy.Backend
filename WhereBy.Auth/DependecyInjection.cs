﻿using Microsoft.Extensions.DependencyInjection;
using WhereBuy.Common.Abstractions;
using WhereBy.Auth.Services;

namespace WhereBy.Auth
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJWTService, JWTService>();
            return services;
        }
    }
}
