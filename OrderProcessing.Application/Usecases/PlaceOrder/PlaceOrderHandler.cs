using MediatR;
using OrderProcessing.Application.Interfaces;
using OrderProcessing.Domain.Entities;
using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Usecases.PlaceOrder;

/// <summary>
/// Handles the PlaceOrderCommand by creating and persisting a new order,
/// then publishing an event to the message queue.
/// </summary>
public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, Guid>
{
    private readonly IOrderRepository _repository;
    private readonly IQueuePublisher _queue;

    /// <summary>
    /// Initializes a new instance of <see cref="PlaceOrderHandler"/> class.
    /// </summary>
    /// <param name="repository">The order repository for data persistence.</param>
    /// <param name="queue">The queue publisher for event broadcasting.</param>
    public PlaceOrderHandler(IOrderRepository repository, IQueuePublisher queue)
    {
        _repository = repository;
        _queue = queue;
    }

    /// <summary>
    /// Handle the command place order.
    /// </summary>
    /// <param name="request">The command containing order details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The unique identifier of the newly created order.</returns>
    public async Task<Guid> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        List<OrderItem> items = request.Order.Items.Select(i => new OrderItem(new ProductId(i.ProductId), i.Quantity, new Money(i.UnitPrice, i.Currency))).ToList();

        Order order = new Order(items);

        await _repository.AddAsync(order, cancellationToken);
        await _queue.PublishOrderPlacedAsync(order, cancellationToken);

        return order.Id;
    }
}
