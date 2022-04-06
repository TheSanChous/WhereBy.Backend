using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereBy.Domain;

namespace WhereBy.Persistence.EntityTypeConfigurations
{
    public class NoticeConfiguration : IEntityTypeConfiguration<Notice>
    {
        public void Configure(EntityTypeBuilder<Notice> builder)
        {
            builder.HasKey(notice => notice.Id);
            builder.HasOne(notice => notice.Shop);
            builder.Property(notice => notice.Created);
            builder.Property(notice => notice.Modified);
            builder.Property(notice => notice.Deleted);
        }
    }
}
