using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WhereBuy.Common.Abstractions;
using WhereBuy.Domain;

namespace WhereBuy.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
