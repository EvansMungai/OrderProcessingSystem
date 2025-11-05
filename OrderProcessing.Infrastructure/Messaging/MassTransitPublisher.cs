using MassTransit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderProcessing.Application.Interfaces;
using OrderProcessing.Domain.Entities;
using OrderProcessing.Domain.Events;

namespace OrderProcessing.Infrastructure.Messaging;

public class MassTransitPublisher : IQueuePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<MassTransitPublisher> _logger;

    public MassTransitPublisher(IPublishEndpoint publishEndpoint, ILogger<MassTransitPublisher> logger)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

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
