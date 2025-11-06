using FluentValidation;
using OrderProcessing.Application.DTOs;

namespace OrderProcessing.Application.Usecases.PlaceOrder;

/// <summary>
/// Validates the PlaceOrderDto to ensure all order items have valid values.
/// </summary>
public class PlaceOrderValidator : AbstractValidator<PlaceOrderDto>
{
    /// <summary>
    /// Intializes a new instance of <see cref="PlaceOrderValidator"/> class and defines the validation rules.
    /// </summary>
    public PlaceOrderValidator()
    {
        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.Quantity).GreaterThan(0);
            items.RuleFor(i => i.UnitPrice).GreaterThan(0);
            items.RuleFor(i => i.Currency).NotEmpty();
        });
    }
}
