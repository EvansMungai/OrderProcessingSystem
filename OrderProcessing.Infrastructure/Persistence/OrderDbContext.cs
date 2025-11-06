using Microsoft.EntityFrameworkCore;
using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Infrastructure.Persistence;

/// <summary>
/// Represents the EF Core database context for managing Order entities.
/// </summary>
public class OrderDbContext : DbContext
{
    /// <summary>
    /// Gets the DbSet for accessing Order records.
    /// </summary>
    public DbSet<Order> Orders => Set<Order>();

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderDbContext"/> class with specified options.
    /// </summary>
    /// <param name="options">The options used to configure the context.</param>
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

    /// <summary>
    /// Configures the entity mappings using Fluent API configurations from the current assembly.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity mappings.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
    }
}
