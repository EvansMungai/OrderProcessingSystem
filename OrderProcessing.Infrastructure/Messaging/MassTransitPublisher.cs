using MassTransit;
using Microsoft.Extensions.Logging;
using OrderProcessing.Application.Interfaces;
using OrderProcessing.Domain.Entities;
using OrderProcessing.Domain.Events;

namespace OrderProcessing.Infrastructure.Messaging;

/// <summary>
/// Publishes order-related events using MassTransit.
/// </summary>
public class MassTransitPublisher : IQueuePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<MassTransitPublisher> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="MassTransitPublisher"/> class.
    /// </summary>
    /// <param name="publishEndpoint">The MassTransit publish endpoint.</param>
    /// <param name="logger">The logger instance.</param>
    public MassTransitPublisher(IPublishEndpoint publishEndpoint, ILogger<MassTransitPublisher> logger)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    /// <summary>
    /// Publishes an OrderPlacedEvent to the message queue.
    /// </summary>
    /// <param name="order">The order to publish.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous publish operation.</returns>
    public async Task PublishOrderPlacedAsync(Order order, CancellationToken cancellationToken)
    {
        var message = new OrderPlacedEvent
        {
            OrderId = order.Id,
            Timestamp = DateTime.UtcNow,
            TotalAmount = order.TotalAmount
        };

        await _publishEndpoint.Publish(message, cancellationToken);
        _logger.LogInformation($"Published OrderPlacedEvent for OrderId {order.Id}");
    }
}
