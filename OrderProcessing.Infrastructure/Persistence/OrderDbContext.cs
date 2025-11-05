using Microsoft.EntityFrameworkCore;
using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Infrastructure.Persistence;

public class OrderDbContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
    }
}
