using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WhereBuy.Common.Abstractions;
using WhereBuy.Application.Common.Behaviors;
using WhereBuy.Application.Common.Services.Mail;
using WhereBuy.Application.Configuration;

namespace WhereBuy.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddConfigurations();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>),
            //    typeof(LoggingBehavior<,>));

            services.AddScoped<IMailService, MailService>();

            return services;
        }
    }
}
