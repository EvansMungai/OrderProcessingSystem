using FluentValidation;
using OrderProcessing.Application.Usecases.PlaceOrder;
using OrderProcessing.Infrastructure.Configuration;

namespace OrderProcessing.API.Configuration;

public static class ServiceRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddInfrastructure(config);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<PlaceOrderCommand>());
        services.AddValidatorsFromAssemblyContaining<PlaceOrderValidator>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
