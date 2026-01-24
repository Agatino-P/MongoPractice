using MongoPractice.Domain;

namespace MongoPractice.Api.EndpointHandlers;

public class GetShoppingListHandler
{
    private readonly ILogger<GetShoppingListHandler> _logger;

    public GetShoppingListHandler(ILogger<GetShoppingListHandler> logger)
    {
        _logger = logger;
    }

    public IResult Process()
    {
        _logger.LogInformation("Getting shopping list...");
        ShList shList = new ShList(Guid.NewGuid(), "Any Name Would Do");
        return Results.Ok(shList.ToView());
    }
}