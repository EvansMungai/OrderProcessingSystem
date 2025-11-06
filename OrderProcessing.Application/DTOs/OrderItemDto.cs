namespace OrderProcessing.Application.DTOs;

/// <summary>
/// Represents a data transfer object for an item in an order.
/// </summary>
public class OrderItemDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product ordered.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the price per unit of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the currency code for the unit price.
    /// </summary>
    public string Currency { get; set; }
}
