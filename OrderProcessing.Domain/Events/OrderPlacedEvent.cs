namespace OrderProcessing.Domain.Events;

/// <summary>
/// Represents an event that occurs when an order is placed.
/// Used to signal other parts of the system that a new order has been created.
/// </summary>
public class OrderPlacedEvent
{
    /// <summary>
    /// Gets or sets the unique identifier of the placed order.
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp indicating when the order was placed.
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the total monetary amount of the placed order.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderPlacedEvent"/> class.
    /// Parameterless constructor for serialization and framework compatibility.
    /// </summary>
    public OrderPlacedEvent() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderPlacedEvent"/> class with the specified order id.
    /// Sets the timestamp to the current system time.
    /// </summary>
    /// <param name="orderId">The unique identifier of the placed order.</param>
    public OrderPlacedEvent(Guid orderId)
    {
        OrderId = orderId;
        Timestamp = DateTime.Now;
    }
}
