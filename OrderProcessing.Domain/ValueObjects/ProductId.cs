namespace OrderProcessing.Domain.ValueObjects;

/// <summary>
/// Represents the unique identifier of a product in the domain.
/// </summary>
/// <param name="value">The globally unique identifier (GUID) of the product.</param>
public record ProductId(Guid value);
