namespace OrderProcessing.Domain.Events;

public class OrderPlacedEvent
{
    public Guid OrderId { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderPlacedEvent() { }
    public OrderPlacedEvent(Guid orderId)
    {
        OrderId = orderId;
        Timestamp = DateTime.Now;
    }
}
