using OrderProcessing.Application.Interfaces;
using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _context;
    public OrderRepository(OrderDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Orders.FindAsync(new object[] {id }, cancellationToken);
    }
}
