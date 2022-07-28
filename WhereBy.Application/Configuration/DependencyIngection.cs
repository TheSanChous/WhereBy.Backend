using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace WhereBy.Application.Configuration
{
    public static class DependencyIngection
    {
        public static IServiceCollection AddConfigurations(
            this IServiceCollection services)
        {
            services.AddScoped(factory =>
            {
                var configuration = new MailConfiguration();
                factory.GetService<IConfiguration>()
                    .GetSection(MailConfiguration.ConfigurationSection)
                    .Bind(configuration);
                return configuration;
            });

            return services;
        }
    }
}
