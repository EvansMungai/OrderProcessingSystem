using MediatR;
using OrderProcessing.Application.DTOs;

namespace OrderProcessing.Application.Usecases.PlaceOrder;

public class PlaceOrderCommand : IRequest<Guid>
{
    public PlaceOrderDto Order { get; set; } 
    public PlaceOrderCommand(PlaceOrderDto order)
    {
        Order = order;
    }
}
