using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Application.Interfaces;

public interface IQueuePublisher
{
    Task PublishOrderPlacedAsync(Order order, CancellationToken cancellationToken);
}
