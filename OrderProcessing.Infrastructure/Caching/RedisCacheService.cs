using Newtonsoft.Json;
using OrderProcessing.Application.Interfaces;
using OrderProcessing.Domain.Entities;
using StackExchange.Redis;

namespace OrderProcessing.Infrastructure.Caching;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _db;
    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public async Task<Domain.Entities.Order?> GetOrderAsync(Guid orderId)
    {
        var json = await _db.StringGetAsync(orderId.ToString());
        return json.HasValue ? JsonConvert.DeserializeObject<Domain.Entities.Order>(json) : null;
    }

    public async Task SetOrderAsync(Domain.Entities.Order order)
    {
        var json = JsonConvert.SerializeObject(order);
        await _db.StringSetAsync(order.Id.ToString(), json, TimeSpan.FromMinutes(10));
    }
}
