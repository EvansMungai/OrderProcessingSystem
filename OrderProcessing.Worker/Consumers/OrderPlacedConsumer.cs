using MassTransit;
using OrderProcessing.Domain.Events;

namespace OrderProcessing.Worker.Consumers;

/// <summary>
/// Consumes OrderPlacedEvent messages and logs order details.
/// </summary>
public class OrderPlacedConsumer : IConsumer<OrderPlacedEvent>
{
    private readonly ILogger<OrderPlacedConsumer> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="OrderPlacedConsumer"/> class.
    /// </summary>
    /// <param name="logger">The logger used to log consumed events.</param>
    public OrderPlacedConsumer(ILogger<OrderPlacedConsumer> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Handles the consumption of an OrderPlacedEvent message.
    /// </summary>
    /// <param name="context">The context containing the event message.</param>
    /// <returns>A completed task.</returns>
    public Task Consume(ConsumeContext<OrderPlacedEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation($"Consumed OrderPlacedEvent: OrderId={context.Message.OrderId}, Total={context.Message.TotalAmount}");
        return Task.CompletedTask;
    }
}
