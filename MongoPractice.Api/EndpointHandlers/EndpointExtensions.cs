namespace MongoPractice.Api.EndpointHandlers;

public static class EndpointServiceExtensions
{
    public static IServiceCollection AddShoppingListHandlers(this IServiceCollection services)
    {
        services.AddScoped<GetShoppingListHandler>();
        return services;
    }
}