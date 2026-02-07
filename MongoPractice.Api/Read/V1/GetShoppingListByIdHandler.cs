using Microsoft.AspNetCore.Http.HttpResults;
using MongoPractice.Contracts.Read.V1.Views;
using MongoPractice.Infrastructure.Database.DataSources.GetShoppingListDataSource;

namespace MongoPractice.Api.Read.V1;

public class GetShoppingListByIdHandler
{
    private readonly IShoppingListDataSource _shoppingListDataSource;
    private readonly ILogger<GetShoppingListByIdHandler> _logger;

    public GetShoppingListByIdHandler(
        IShoppingListDataSource shoppingListDataSource,
        ILogger<GetShoppingListByIdHandler> logger)
    {
        _shoppingListDataSource = shoppingListDataSource;
        _logger = logger;
    }

    public async Task<Results<ProblemHttpResult, Ok<ShListViewV1>>> Process(Guid id)
    {
        _logger.LogMemberCalled();
        EitherAsync<Error, ShListViewV1> eitherAsync =
            _shoppingListDataSource.GetDetail(id).ToAsync();
                
        Either<Error, ShListViewV1> either=await eitherAsync;
        
        return either.Match<Results<ProblemHttpResult, Ok<ShListViewV1>>>(
            shListView =>TypedResults.Ok(shListView),
            error =>TypedResults.Problem("ID cannot be found", statusCode: 400)
        );
    }
    
}