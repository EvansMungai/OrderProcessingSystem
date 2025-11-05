using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Domain.Entities;

public class OrderItem 
{
    public Guid Id { get; private set; }
    public ProductId ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Money UnitPrice { get; private set; }

    public Money TotalPrice => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);

    public OrderItem(ProductId productId, int quantity, Money unitPrice)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

}
