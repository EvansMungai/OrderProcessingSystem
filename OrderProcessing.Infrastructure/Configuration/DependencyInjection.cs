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
        var queueSettings = config.GetSection("QueueSettings").Get<QueueSettings>();
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
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
