using MassTransit;
using OrderProcessing.Infrastructure.Messaging;
using OrderProcessing.Worker.Consumers;

namespace OrderProcessing.Worker.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddWorkerServices(this IServiceCollection services, IConfiguration config)
    {
        var queueSettings = config.GetSection("QueueSettings").Get<QueueSettings>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderPlacedConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(queueSettings.Host, h =>
                {
                    h.Username(queueSettings.Username);
                    h.Password(queueSettings.Password);
                });
                cfg.ReceiveEndpoint("order-placed", e =>
                {
                    e.ConfigureConsumer<OrderPlacedConsumer>(context);
                });
            });
        });

        return services;
    }
}
