using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereBuy.Domain;

namespace WhereBuy.Persistence.EntityTypeConfigurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(shop => shop.Id);
            builder.Property(shop => shop.Name);
            builder.Property(shop => shop.Address);
            builder.Property(shop => shop.Location);
        }
    }
}
