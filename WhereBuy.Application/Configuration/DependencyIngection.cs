using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WhereBuy.Application.Configuration
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
