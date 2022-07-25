using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using WhereBy.Application.Common.Behaviors;
using WhereBy.Application.Interfaces;
using WhereBy.Application.Common.Services.Mail;
using WhereBy.Application.Configuration;
using System.Net;

namespace WhereBy.Application
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
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));

            services.AddScoped<IMailService, MailService>();

            return services;
        }
    }
}
