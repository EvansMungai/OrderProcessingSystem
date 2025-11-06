using Newtonsoft.Json;
using OrderProcessing.Application.Interfaces;
using StackExchange.Redis;

namespace OrderProcessing.Infrastructure.Caching;

/// <summary>
/// Provides Redis-based caching functionality for storing and retrieving orders.
/// </summary>
public class RedisCacheService : ICacheService
{
    private readonly IDatabase _db;

    /// <summary>
    /// Intializes a new instance of <see cref="RedisCacheService"/> class.
    /// </summary>
    /// <param name="redis">The Redis connection multiplexer.</param>
    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    /// <summary>
    /// Asynchronously retrieves an order from Redis by its unique identifier.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order.</param>
    /// <returns>The order if found; otherwise null.</returns>
    public async Task<Domain.Entities.Order?> GetOrderAsync(Guid orderId)
    {
        var json = await _db.StringGetAsync(orderId.ToString());
        return json.HasValue ? JsonConvert.DeserializeObject<Domain.Entities.Order>(json) : null;
    }

    /// <summary>
    /// Asynchronously stores an order in Redis with a 10-minute expiration.
    /// </summary>
    /// <param name="order">The order to cache.</param>
    /// <returns>A task representing the asynchrounous operation.</returns>
    public async Task SetOrderAsync(Domain.Entities.Order order)
    {
        var json = JsonConvert.SerializeObject(order);
        await _db.StringSetAsync(order.Id.ToString(), json, TimeSpan.FromMinutes(10));
    }
}
