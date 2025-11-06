using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Application.Interfaces;

/// <summary>
/// Defines a contract for publishing order-related events to a message queue.
/// </summary>
public interface IQueuePublisher
{
    /// <summary>
    /// Asynchronously publishes an event indicating that an order has been placed.
    /// </summary>
    /// <param name="order">The order to publish.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task PublishOrderPlacedAsync(Order order, CancellationToken cancellationToken);
}
