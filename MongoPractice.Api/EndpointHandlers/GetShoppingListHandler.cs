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
        return Results.Ok("A ShoppingList from Instance");
    }
}