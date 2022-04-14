using Microsoft.Extensions.DependencyInjection;
using WhereBy.Application.Interfaces;
using WhereBy.WebApi.Services.Auth;
using WhereBy.WebApi.Services.JWT;

namespace WhereBy.WebApi.Services
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJWTService, JWTService>();
            return services;
        }
    }
}
