using OrderProcessing.Domain.Enums;
using OrderProcessing.Domain.Interfaces;

namespace OrderProcessing.Domain.Entities;

/// <summary>
/// Represents an order in the system, serving as the aggregate root in the domain model.
/// </summary>
public class Order : IAggregateRoot
{
    /// <summary>
    /// Gets the unique identifier of the order.
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Gets the UTC timestamp when the order was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Gets the current status of the order.
    /// </summary>
    public OrderStatus Status { get; private set; }

    /// <summary>
    /// Gets the list of items included in the order.
    /// </summary>
    public List<OrderItem> Items { get; private set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Order"/> class.
    /// Private constructor for ORM and serialization purposes.
    /// </summary>
    private Order() { }

    /// <summary>
    /// Initalizes a new instance of the <see cref="Order"/> class with the specified items.
    /// </summary>
    /// <param name="items">The list of items to include in the order.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is null.</exception>
    public Order(List<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.Pending;
        Items = items ?? throw new ArgumentNullException(nameof(items));
    }

    /// <summary>
    /// Marks the order as processed if it is currently pending.
    /// </summary>
    /// <exception cref="InvalidOperationException">thrown when the order is not in a pending state.</exception>
    public void MarkAsProcessed()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be processed.");

        Status = OrderStatus.Processed;
    }

    /// <summary>
    /// Gets the total monetary amount of the order by summing the total price of each item.
    /// </summary>
    public decimal TotalAmount => Items.Sum(i => i.TotalPrice.Amount);

}
