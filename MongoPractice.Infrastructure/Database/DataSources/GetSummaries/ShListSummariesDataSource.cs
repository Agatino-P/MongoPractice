using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoPractice.Contracts.Read.V1.Views;
using MongoPractice.Infrastructure.MongoContext;
using MongoPractice.ServiceDefaults;

namespace MongoPractice.Infrastructure.Database.DataSources.GetSummaries;

public class ShListSummariesDataSource : IShListSummariesDataSource
{
    private readonly IShListMongoContext _shListMongoContext;
    private readonly ILogger<ShListSummariesDataSource> _logger;

    public ShListSummariesDataSource(IShListMongoContext shListMongoContext, ILogger<ShListSummariesDataSource> logger)
    {
        _shListMongoContext = shListMongoContext;
        _logger = logger;
    }

    public async Task<Either<Error, IEnumerable<ShListSummaryViewV1>>> GetSummaries()
    {
        try
        {
            var shListsCollection = _shListMongoContext.GetShoppingListCollection<ShListDoc>();

            List<ShListSummaryViewV1> shoppingListSummaries = await shListsCollection.AsQueryable()
                .Select(doc =>
                    new ShListSummaryViewV1(
                        Id: doc.Id,
                        Name: doc.Name,
                        NumberOfItems: (doc.ShItems?? new List<ShItemDoc>()).Count
                    ))
                .ToListAsync();

            return Either<Error, IEnumerable<ShListSummaryViewV1>>.Right(shoppingListSummaries.AsEnumerable());
        }
        catch (Exception e)
        {
            const string errorMessage = "Couldn't retrieve summaries";
            _logger.LogError(e, errorMessage);
            return Error.New(errorMessage);
        }
    }

    protected record ShListDoc(
        [property: BsonId] ObjectId MongoId,
        [property: BsonRepresentation(BsonType.String)]
        Guid Id,
        string Name,
        List<ShItemDoc>? ShItems
    );

    protected record ShItemDoc(
        [property: BsonId] ObjectId MongoId,
        [property: BsonRepresentation(BsonType.String)]
        Guid Id,
        string Name,
        int Quantity);
}

