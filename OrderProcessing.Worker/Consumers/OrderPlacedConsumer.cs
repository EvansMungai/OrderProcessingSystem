using MassTransit;
using OrderProcessing.Domain.Events;

namespace OrderProcessing.Worker.Consumers;

public class OrderPlacedConsumer : IConsumer<OrderPlacedEvent>
{
    private readonly ILogger<OrderPlacedConsumer> _logger;

    public OrderPlacedConsumer(ILogger<OrderPlacedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<OrderPlacedEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation($"Consumed OrderPlacedEvent: OrderId={context.Message.OrderId}, Total={context.Message.TotalAmount}");
        return Task.CompletedTask;
    }
}
