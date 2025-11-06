using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Application.Interfaces;

/// <summary>
/// Defines caching operations for storing and retrieving orders.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Asynchronously retrieves an order from the cache by its unique identifier.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order.</param>
    /// <returns>The cached order if found; otherwise, null.</returns>
    Task<Order?> GetOrderAsync(Guid orderId);

    /// <summary>
    /// Asynchronously stores an order in the cache.
    /// </summary>
    /// <param name="order">The order to cache.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SetOrderAsync(Order order);
}
