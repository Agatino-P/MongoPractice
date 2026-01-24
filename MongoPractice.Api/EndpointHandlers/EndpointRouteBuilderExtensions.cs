using Asp.Versioning;
using Asp.Versioning.Builder;

namespace MongoPractice.Api.EndpointHandlers;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1.0))
            .ReportApiVersions()
            .Build();

        RouteGroupBuilder apiGroup = app.MapGroup("/api/v{version:apiVersion}")
            .WithApiVersionSet(apiVersionSet);

        apiGroup.MapGet("/ShoppingList", (GetShoppingListHandler handler) => handler.Process());

        return app;
    }
}