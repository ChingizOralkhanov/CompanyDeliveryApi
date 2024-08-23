using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class CargoItemConfiguration : IEntityTypeConfiguration<CargoItem>
{
    public void Configure(EntityTypeBuilder<CargoItem> builder)
    {
        builder.Property(c => c.Number)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(c => new { c.WaybillId, c.Number })
            .IsUnique();
    }
}