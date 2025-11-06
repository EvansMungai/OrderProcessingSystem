namespace OrderProcessing.Domain.ValueObjects;

/// <summary>
/// Represents a monetary value with a specified amount and currency.
/// </summary>
/// <param name="Amount">The numeric value of the money.</param>
/// <param name="Currency">The currency code (e.g. USD, EUR) associated with the amount.</param>
public record Money(decimal Amount, string Currency);
