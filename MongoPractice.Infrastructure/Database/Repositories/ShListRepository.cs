using Ag.Api.Extension;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoPractice.Domain.Aggregates;
using MongoPractice.Infrastructure.Database.Entities;
using MongoPractice.Infrastructure.MongoContext;

namespace MongoPractice.Infrastructure.Database.Repositories;

public partial class ShListRepository : IShListRepository
{
    private readonly ILogger<ShListRepository> _logger;
    private readonly IMongoCollection<ShListEntity> _shListsCollection;

    public ShListRepository(IShListMongoContext shListMongoContext, ILogger<ShListRepository> logger)
    {
        _shListsCollection = shListMongoContext.GetShoppingListCollection<ShListEntity>();
        _logger = logger;
    }


    public async Task<Either<Error, Unit>> Add(ShList shList)
    {
        logAddCalled(nameof(ShListRepository), nameof(Add), CustomJson.Serialize(shList));

        try
        {
            await _shListsCollection.InsertOneAsync(ShListEntity.FromShList(shList));
            return Unit.Default;
        }
        catch (Exception ex)
        {
            return Error.New(ex);
        }
    }

    private static ShItem toShItem(ShItemEntity shItemEntity)
        => new ShItem(shItemEntity.Id, shItemEntity.Name, shItemEntity.Quantity, shItemEntity.Status);

    [LoggerMessage(LogLevel.Information, "{className}.{methodName} was called with payload {jsonPayload}")]
    partial void logAddCalled(string className, string methodName, string jsonPayload);
}