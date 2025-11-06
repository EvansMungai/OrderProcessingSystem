using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderProcessing.Application.Interfaces;
using OrderProcessing.Infrastructure.Caching;
using OrderProcessing.Infrastructure.Messaging;
using OrderProcessing.Infrastructure.Persistence;
using StackExchange.Redis;

namespace OrderProcessing.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // PostgreSQL
        services.AddDbContext<OrderDbContext>(options => options.UseNpgsql(config.GetConnectionString("Postgres")));

        // Redis
        services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(config.GetConnectionString("Redis")));

        // MassTransit + RabbitMQ
        services.Configure<QueueSettings>(config.GetSection("QueueSettings"));
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                if (config == null)
                    throw new InvalidOperationException("Configuration object is null in Add Infrastructure services");

                var section = config.GetSection("QueueSettings");
                if (!section.Exists())
                    throw new InvalidOperationException("QueueSettings section is missing in configuration");

                var queueSettings = section.Get<QueueSettings>();
                if (queueSettings == null)
                    throw new InvalidOperationException("QueueSettings could not be bound to QueueSettings class.");

                cfg.Host(queueSettings.Host, h =>
                {
                    h.Username(queueSettings.Username);
                    h.Password(queueSettings.Password);
                });
            });
        });

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IQueuePublisher, MassTransitPublisher>();
        services.AddScoped<ICacheService, RedisCacheService>();

        return services;
    }
}
