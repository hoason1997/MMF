using MFF.DTO.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFF.Infrastructure.Configurations
{
    class MFFItemConfiguration : IEntityTypeConfiguration<MFFItem>
    {
        public void Configure(EntityTypeBuilder<MFFItem> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
        }
    }
}
