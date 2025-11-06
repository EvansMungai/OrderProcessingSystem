using MediatR;
using OrderProcessing.Application.DTOs;

namespace OrderProcessing.Application.Usecases.PlaceOrder;

/// <summary>
/// Represents a command to place a new order.
/// </summary>
public class PlaceOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// Gets or sets the order details to be placed.
    /// </summary>
    public PlaceOrderDto Order { get; set; } 

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaceOrderCommand"/> class with the specified order details.
    /// </summary>
    /// <param name="order">The order data transfer object containing order information.</param>
    public PlaceOrderCommand(PlaceOrderDto order)
    {
        Order = order;
    }
}
