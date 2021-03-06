using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WhereBuy.Application.Common.Behaviors;
using WhereBuy.Application.Common.Mappings;
using WhereBuy.Application.Common.Services.Mail;
using WhereBuy.Common.Abstractions;
using WhereBuy.Common.Configuration;

namespace WhereBuy.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services, Assembly assembly)
        {
            services.AddConfigurations();

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(AssemblyMappingProfile).Assembly));
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));

            services.AddScoped<IMailService, MailService>();

            return services;
        }
    }
}
