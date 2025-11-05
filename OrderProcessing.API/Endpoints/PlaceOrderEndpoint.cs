using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OrderProcessing.Application.DTOs;
using OrderProcessing.Application.Usecases.PlaceOrder;

namespace OrderProcessing.API.Endpoints;

public static class PlaceOrderEndpoint
{
    public static void MapPlaceOrder(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/orders", async (PlaceOrderDto dto, IValidator<PlaceOrderDto> validator, IMediator mediator) =>
        {
            ValidationResult result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return Results.BadRequest(errors);
            }

            var command = new PlaceOrderCommand(dto);
            var orderId = await mediator.Send(command);
            return Results.Created($"/api/orders/{orderId}", new { orderId });
        });
    }
}
