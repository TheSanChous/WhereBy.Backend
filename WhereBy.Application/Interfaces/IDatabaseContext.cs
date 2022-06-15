using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhereBuy.Domain;

namespace WhereBuy.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Notice> Notices { get; set; }
        DbSet<Shop> Shops { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
