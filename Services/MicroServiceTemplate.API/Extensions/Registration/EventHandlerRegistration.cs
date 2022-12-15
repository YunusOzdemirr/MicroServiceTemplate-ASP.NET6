namespace MicroServiceTemplate.API.Extensions.Registration;

public static class EventHandlerRegistration
{
    public static IServiceCollection ConfigureEventHandlers(this IServiceCollection services)
    {
        // services.AddTransient<OrderCreatedIntegrationEventHandler>();
        return services;
    }
}