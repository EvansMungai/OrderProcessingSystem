using MediatR;
using OrderProcessing.Application.Interfaces;
using OrderProcessing.Domain.Entities;
using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Usecases.PlaceOrder;

public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, Guid>
{
    private readonly IOrderRepository _repository;
    private readonly IQueuePublisher _queue;
    public PlaceOrderHandler(IOrderRepository repository, IQueuePublisher queue)
    {
        _repository = repository;
        _queue = queue;
    }

    public async Task<Guid> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var items = request.Order.Items.Select(i => new OrderItem(new ProductId(i.ProductId), i.Quantity, new Money(i.UnitPrice, i.Currency))).ToList();

        var order = new Order(items);

        await _repository.AddAsync(order, cancellationToken);
        await _queue.PublishOrderPlacedAsync(order, cancellationToken);

        return order.Id;
    }
}
