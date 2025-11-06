namespace OrderProcessing.Domain.Enums;

/// <summary>
/// Represents the status of an order during its lifecycle.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// The order has been created but not yet processed.
    /// </summary>
    Pending = 0,

    /// <summary>
    /// The order has been successfully processed.
    /// </summary>
    Processed = 1,

    /// <summary>
    /// The order processing has failed.
    /// </summary>
    Failed =2
}
