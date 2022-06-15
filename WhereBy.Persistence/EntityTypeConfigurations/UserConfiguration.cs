using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereBuy.Domain;

namespace WhereBuy.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Name);
            builder.Property(user => user.Phone);
            builder.Property(user => user.Email);
            builder.Property(user => user.PasswordHash);
            builder.Property(user => user.PasswordSalt);
            builder.Property(user => user.Points);
        }
    }
}
