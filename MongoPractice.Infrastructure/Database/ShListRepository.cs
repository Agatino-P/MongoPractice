using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoPractice.Infrastructure.Database.Entities;
using MongoPractice.ServiceDefaults;
using System.Globalization;

namespace MongoPractice.Infrastructure.Database;

public class ShListRepository : IShListRepository
{
    private readonly IMongoClient _client;
    private readonly ILogger<ShListRepository> _logger;
    private readonly IMongoCollection<ShListEntity> _shListsCollection;

    public ShListRepository(IMongoClient client, ILogger<ShListRepository> logger)
    {
        var database = client.GetDatabase(ResourceNames.MongoDb);
        _shListsCollection = database.GetCollection<ShListEntity>("shopping_lists");

        _client = client;
        _logger = logger;
    }

    public async Task<Either<Error, ShList>> GetById(Guid id)
    {
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
        bool exists = await _shListsCollection.AsQueryable()
            .AnyAsync(x => x.Id == shList.Id);

        if (exists)
        {
            return Error.New($"ShList with id {shList.Id} already exists");
        }

        await _shListsCollection.InsertOneAsync(toShListEntity(shList));
        return Unit.Default;
    }


    private static ShList toShList(ShListEntity entity)
    {
        return new ShList(entity.Id, entity.Name);
    }

    private static ShListEntity toShListEntity(ShList shList)
    {
        object newMongoId = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        return new ShListEntity(shList.Id, shList.Name);
    }
}