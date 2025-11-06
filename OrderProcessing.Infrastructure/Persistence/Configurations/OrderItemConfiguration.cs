using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configures the EF Core mapping for the OrderItem entity.
/// </summary>
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    /// <summary>
    /// Applies configuration ruels to the OrderItem entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
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
