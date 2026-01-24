using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using MongoPractice.Application.UseCases.GetShoppingList;
using MongoPractice.Domain;

namespace MongoPractice.Api.EndpointHandlers;

public class GetShoppingListHandler
{
    private readonly IGetShoppingListByIdPipeline _getShoppingListByIdPipeline;
    private readonly ILogger<GetShoppingListHandler> _logger;

    public GetShoppingListHandler(
        IGetShoppingListByIdPipeline getShoppingListByIdPipeline,
        ILogger<GetShoppingListHandler> logger)
    {
        _getShoppingListByIdPipeline = getShoppingListByIdPipeline;
        _logger = logger;
    }

    public async Task<IResult> Process(Guid id)
    {
        _logger.LogInformation("Getting shopping list...");
        Either<ProblemDetails, ShList> either = await _getShoppingListByIdPipeline.Process(id);

        return either.Match<IResult>(
            shList => Results.Ok(shList.ToView()),
            pd => Results.Json(data: pd, statusCode: (pd.Status ?? StatusCodes.Status500InternalServerError))
        );
    }
}