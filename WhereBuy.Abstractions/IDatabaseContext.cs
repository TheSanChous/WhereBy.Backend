using Microsoft.EntityFrameworkCore;
using WhereBy.Domain;

namespace WhereBy.Abstractions
{
    public interface IDatabaseContext
    {
        DbSet<Notice> Notices { get; set; }
        DbSet<Shop> Shops { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
