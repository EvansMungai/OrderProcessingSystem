namespace OrderProcessing.Domain.Events;

public class OrderPlacedEvent
{
    public Guid OrderId { get; }
    public DateTime Timestamp { get; }
    public OrderPlacedEvent(Guid orderId)
    {
        OrderId = orderId;
        Timestamp = DateTime.Now;
    }
}
