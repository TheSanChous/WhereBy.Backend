using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WhereBy.Abstractions;
using WhereBy.Domain;

namespace WhereBy.Persistence
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
