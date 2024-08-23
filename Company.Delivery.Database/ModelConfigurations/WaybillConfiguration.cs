using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class WaybillConfiguration : IEntityTypeConfiguration<Waybill>
{
    public void Configure(EntityTypeBuilder<Waybill> builder)
    {
        builder.Property(w => w.Number)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasIndex(w => w.Number)
            .IsUnique();
    }
}