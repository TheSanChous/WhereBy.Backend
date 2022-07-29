using Microsoft.Extensions.DependencyInjection;
using WhereBuy.Auth.Services;
using WhereBuy.Common.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WhereBuy.Common.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WhereBuy.Auth
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var configuration = services.BuildServiceProvider().GetRequiredService<JWTConfiguration>();
                var Key = Encoding.UTF8.GetBytes(configuration.Key);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.Issuer,
                    ValidAudience = configuration.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJWTService, JWTService>();
            return services;
        }
    }
}
