using Microsoft.EntityFrameworkCore;
using WhereBy.Domain;

namespace WhereBuy.Common.Abstractions
{
    public interface IDatabaseContext
    {
        DbSet<Notice> Notices { get; set; }
        DbSet<Shop> Shops { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
