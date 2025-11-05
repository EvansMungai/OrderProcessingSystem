using OrderProcessing.Domain.Enums;
using OrderProcessing.Domain.Interfaces;

namespace OrderProcessing.Domain.Entities;

public class Order : IAggregateRoot
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();

    public Order(List<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.Pending;
        Items = items ?? throw new ArgumentNullException(nameof(items));
    }

    public void MarkAsProcessed()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be processed.");

        Status = OrderStatus.Processed;
    }

    public decimal TotalAmount => Items.Sum(i => i.TotalPrice.Amount);

}
