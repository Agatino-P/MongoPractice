using Ag.Api.Extension;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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

    public async Task<Either<Error, ShList>> GetById(Guid id)
    {
        logAddCalled(nameof(ShListRepository), nameof(Add), CustomJson.Serialize(new { id }));

        ShListEntity? nullableEntity = await _shListsCollection.AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        Either<Error, ShList> either =
            Optional(nullableEntity)
                .ToEither(Error.New($"ShList with id {id} Not found"))
                .Map(toShList);

        return either;
    }

    public async Task<Either<Error, Unit>> Add(ShList shList)
    {
        logAddCalled(nameof(ShListRepository), nameof(Add), CustomJson.Serialize(shList));

        bool exists = await _shListsCollection.AsQueryable()
            .AnyAsync(x => x.Id == shList.Id);

        //TODO: replace this logic with proper use of upsert, after clarifying the use case for when the record is there
        //what is here is subject to race if you don't use a GUID
        if (exists)
        {
            return Error.New($"ShList with id {shList.Id} already exists");
        }

        await _shListsCollection.InsertOneAsync(ShListEntity.FromShList(shList));
        return Unit.Default;
    }


    private static ShList toShList(ShListEntity entity) =>
        new(entity.Id, entity.Name, entity.ShItems.Select(toShItem));

    private static ShItem toShItem(ShItemEntity shItemEntity)
        => new ShItem(shItemEntity.Id, shItemEntity.Name, shItemEntity.Quantity);

    [LoggerMessage(LogLevel.Information, "{className}.{methodName} was called with payload {jsonPayload}")]
    partial void logAddCalled(string className, string methodName, string jsonPayload);
}