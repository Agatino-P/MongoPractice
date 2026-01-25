namespace MongoPractice.Api.EndpointHandlers.Extensions;

public static class EndpointServiceExtensions
{
    public static IServiceCollection AddShoppingListHandlers(this IServiceCollection services)
    {
        services.AddScoped<GetShoppingListHandler>();
        services.AddScoped<CreateShoppingListHandler>();
        return services;
    }
}