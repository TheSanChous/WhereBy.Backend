using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhereBy.Abstractions;

namespace WhereBy.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
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
