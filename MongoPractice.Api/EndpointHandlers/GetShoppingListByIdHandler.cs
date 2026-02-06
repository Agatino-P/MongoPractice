using Microsoft.AspNetCore.Mvc;
using MongoPractice.Application.UseCases.GetShoppingList;
using MongoPractice.Domain;

namespace MongoPractice.Api.EndpointHandlers;

public class GetShoppingListByIdHandler
{
    private readonly IGetShoppingListByIdPipeline _getShoppingListByIdPipeline;
    private readonly ILogger<GetShoppingListByIdHandler> _logger;

    public GetShoppingListByIdHandler(
        IGetShoppingListByIdPipeline getShoppingListByIdPipeline,
        ILogger<GetShoppingListByIdHandler> logger)
    {
        _getShoppingListByIdPipeline = getShoppingListByIdPipeline;
        _logger = logger;
    }

    public async Task<IResult> Process(Guid id)
    {
        _logger.LogInformation("Getting shopping list...");
        EitherAsync<ProblemDetails, ShList> eitherAsync = 
            _getShoppingListByIdPipeline.Process(id).ToAsync()
                .MapLeft(toProblemDetails);
        
        
        var either=await eitherAsync;
        
        return either.Match<IResult>(
            shList => Results.Ok(shList.ToView()),
            pd => Results.Json(data: pd, statusCode: (pd.Status ?? StatusCodes.Status500InternalServerError))
        );
    }
    private static ProblemDetails toProblemDetails(Error error)
        => new ProblemDetails(){Detail =  error.Message};
}