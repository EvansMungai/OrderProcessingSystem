using FluentValidation;
using OrderProcessing.Application.DTOs;

namespace OrderProcessing.Application.Usecases.PlaceOrder;

public class PlaceOrderValidator : AbstractValidator<PlaceOrderDto>
{
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
