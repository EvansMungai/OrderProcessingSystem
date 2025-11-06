using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Application.Interfaces;

/// <summary>
/// Defines methods for accessing and managing order data in a repository.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Asynchronously adds a new order to the repository.
    /// </summary>
    /// <param name="order">The order to add.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(Order order, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves an order by its unique identifer.
    /// </summary>
    /// <param name="id">The unique identifier of the order.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
