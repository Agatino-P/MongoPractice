using Asp.Versioning;
using Asp.Versioning.Builder;
using MongoPractice.Contracts.V1.Dtos;

namespace MongoPractice.Api.EndpointHandlers.Extensions;

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

        apiGroup.MapGet("/ShoppingList/{id:guid}", (GetShoppingListHandler handler, Guid id) => handler.Process(id));
        apiGroup.MapPost("/ShoppingList", (CreateShoppingListHandler handler, CreateShListDtoV1 dto) => handler.Process(dto));

        return app;
    }
}