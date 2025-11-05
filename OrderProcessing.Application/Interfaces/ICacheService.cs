using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Application.Interfaces;

public interface ICacheService
{
    Task<Order?> GetOrderAsync(Guid orderId);
    Task SetOrderAsync(Order order);
}
