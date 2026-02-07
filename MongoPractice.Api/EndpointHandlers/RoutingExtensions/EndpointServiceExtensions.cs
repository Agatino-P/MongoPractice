using MongoPractice.Api.Read.V1;

namespace MongoPractice.Api.EndpointHandlers.RoutingExtensions;

public static class EndpointServiceExtensions
{
    public static IServiceCollection AddShoppingListHandlers(this IServiceCollection services)
    {
        services.AddScoped<GetShoppingListSummariesHandler>();
        services.AddScoped<GetShoppingListByIdHandler>();
        services.AddScoped<Write.V1.CreateShoppingListHandler>();
        return services;
    }
}