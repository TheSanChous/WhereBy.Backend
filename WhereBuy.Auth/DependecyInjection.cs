using Microsoft.Extensions.DependencyInjection;
using WhereBuy.Auth.Services;
using WhereBuy.Common.Abstractions;

namespace WhereBuy.Auth
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
