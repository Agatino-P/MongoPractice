using MongoPractice.Contracts.Read.V1.Views;
using MongoPractice.Infrastructure.Database.DataSources.GetSummaries;

namespace MongoPractice.Api.Read.V1;

public class GetShoppingListSummariesHandler
{
    private readonly IShListSummariesDataSource _shListSummariesDataSource;
    private readonly ILogger<GetShoppingListSummariesHandler> _logger;

    public GetShoppingListSummariesHandler(
        IShListSummariesDataSource shListSummariesDataSource,
        ILogger<GetShoppingListSummariesHandler> logger)
    {
        _shListSummariesDataSource = shListSummariesDataSource;
        _logger = logger;
    }

    public async Task<IResult> Process()
    {
        _logger.LogMemberCalled();
        EitherAsync<ProblemDetails, IEnumerable<ShListSummaryViewV1>> eitherAsync = 
            _shListSummariesDataSource.GetSummaries().ToAsync()
                .MapLeft(toProblemDetails);
        
        
        Either<ProblemDetails, IEnumerable<ShListSummaryViewV1>> either=await eitherAsync;
        
        return either.Match<IResult>(
            Results.Ok,
            pd => Results.Json(data: pd, statusCode: (pd.Status ?? StatusCodes.Status500InternalServerError))
        );
    }

    private static ProblemDetails toProblemDetails(Error error)
        => new ProblemDetails(){Detail =  error.Message};
}