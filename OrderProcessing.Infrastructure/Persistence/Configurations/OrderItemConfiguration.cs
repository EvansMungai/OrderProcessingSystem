using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Quantity)
            .IsRequired();

        // Configure ProductId as value object
        builder.OwnsOne(x => x.ProductId, b =>
        {
            b.Property(p => p.value)
            .HasColumnName("ProductId")
            .IsRequired();
        });

        // Configure Money as value object
        builder.OwnsOne(x => x.UnitPrice, b =>
        {
            b.Property(p => p.Amount)
            .HasColumnName("UnitPrice")
            .IsRequired();

            b.Property(p => p.Currency)
            .HasColumnName("Currency")
            .IsRequired();
        });

        builder.Ignore(x => x.TotalPrice); // Computed, not persisted
    }
}
