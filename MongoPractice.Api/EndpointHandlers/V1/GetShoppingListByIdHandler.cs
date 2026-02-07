using MongoPractice.Application.UseCases.GetShoppingList;
using MongoPractice.Contracts.Read.V1.Views;
using MongoPractice.Domain.Aggregates;

namespace MongoPractice.Api.EndpointHandlers.V1;

public class GetShoppingListByIdHandler
{
    private readonly IGetShoppingListByIdPipeline _getShoppingListByIdPipeline;
    private readonly ILogger<GetShoppingListByIdHandler> _logger;

    public GetShoppingListByIdHandler(
        //TODO for read, get rid of the pipeline, datasource is enough
        IGetShoppingListByIdPipeline getShoppingListByIdPipeline,
        ILogger<GetShoppingListByIdHandler> logger)
    {
        _getShoppingListByIdPipeline = getShoppingListByIdPipeline;
        _logger = logger;
    }

    public async Task<IResult> Process(Guid id)
    {
        _logger.LogMemberCalled();
        EitherAsync<ProblemDetails, ShList> eitherAsync = 
            _getShoppingListByIdPipeline.Process(id).ToAsync()
                .MapLeft(toProblemDetails);
        
        
        Either<ProblemDetails, ShList> either=await eitherAsync;
        
        return either.Match<IResult>(
            shList => Results.Ok(toShListViewV1),
            pd => Results.Json(data: pd, statusCode: (pd.Status ?? StatusCodes.Status500InternalServerError))
        );
    }
    
    private static ShListViewV1 toShListViewV1(ShList shList)
        => new ShListViewV1(shList.Id, shList.Name);
    
    private static ProblemDetails toProblemDetails(Error error)
        => new ProblemDetails(){Detail =  error.Message};
}