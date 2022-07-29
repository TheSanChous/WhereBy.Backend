using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WhereBuy.Common.Configuration
{
    public static class DependencyIngection
    {
        public static IServiceCollection AddConfigurations(
            this IServiceCollection services)
        {
            var types = GetTypesWithServiceConfigurationAttribute(Assembly.GetExecutingAssembly());

            foreach(var type in types)
            {
                services.AddSingleton(type, factory =>
                {
                    var configuration = Activator.CreateInstance(type);
                    factory.GetService<IConfiguration>()
                        .GetSection(type.GetCustomAttribute<ServiceConfigurationAttribute>().ConfigurationSection)
                        .Bind(configuration);
                    return configuration;
                });
            }

            return services;
        }

        private static IEnumerable<Type> GetTypesWithServiceConfigurationAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(ServiceConfigurationAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
