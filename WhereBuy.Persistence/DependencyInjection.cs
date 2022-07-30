using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WhereBuy.Common.Abstractions;
using WhereBuy.Common.Configuration;

namespace WhereBuy.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services)
        {
            var servicesProvider = services.BuildServiceProvider();

            var configuration = servicesProvider.GetService<DatabaseConfiguration>();
            var environment = servicesProvider.GetService<IWebHostEnvironment>();

            var connectionString = configuration.DefaultConnection;

            if (environment.IsDevelopment())
            {
                connectionString = configuration.LocalConnection;
            }

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IDatabaseContext>(provider =>
                provider.GetService<DatabaseContext>());
            return services;
        }
    }
}
