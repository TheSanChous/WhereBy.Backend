using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WhereBuy.Common.Abstractions;
using WhereBy.Application.Common.Behaviors;
using WhereBy.Application.Common.Services.Mail;
using WhereBy.Application.Configuration;

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
            //services.AddTransient(typeof(IPipelineBehavior<,>),
            //    typeof(LoggingBehavior<,>));

            services.AddScoped<IMailService, MailService>();

            return services;
        }
    }
}
