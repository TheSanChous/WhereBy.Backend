using Microsoft.Extensions.DependencyInjection;
using WhereBuy.Application.Interfaces;
using WhereBuy.WebApi.Services.Auth;
using WhereBuy.WebApi.Services.JWT;

namespace WhereBuy.WebApi.Services
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
