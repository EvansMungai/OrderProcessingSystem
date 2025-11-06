namespace OrderProcessing.Application.DTOs;

/// <summary>
/// Represents a data transfer object used to place an order.
/// </summary>
public class PlaceOrderDto
{
    /// <summary>
    /// Gets or sets the list of items included in the order.
    /// </summary>
    public List<OrderItemDto> Items { get; set; } = new();
}
