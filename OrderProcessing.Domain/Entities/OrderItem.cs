using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Domain.Entities;

/// <summary>
/// Represents a single item within an order, including product reference, quantity and pricing details.
/// </summary>
public class OrderItem 
{
    /// <summary>
    /// Gets the unique identifier of the order item.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the unique identifier of the product associated with this order item.
    /// </summary>
    public ProductId ProductId { get; private set; }

    /// <summary>
    /// Gets the quantity of the product ordered.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Gets the unit price of the product ordered.
    /// </summary>
    public Money UnitPrice { get; private set; }

    /// <summary>
    /// Gets the total price for this order item, calculated as UnitPrice multiplied by Quantity.
    /// </summary>
    public Money TotalPrice => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderItem"/> class.
    /// Private constructor for ORM and serialization purposes.
    /// </summary>
    private OrderItem() { }

    /// <summary>
    /// Initializes a new instanc eof the <see cref="OrderItem"/> class with the specified product, quantity and unit price.
    /// </summary>
    /// <param name="productId">The identifier of the product being ordered.</param>
    /// <param name="quantity">The number of units ordered.</param>
    /// <param name="unitPrice">The price per unit of the product.</param>
    public OrderItem(ProductId productId, int quantity, Money unitPrice)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

}
