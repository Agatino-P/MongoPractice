using MongoDB.Driver;

namespace MongoPractice.Infrastructure.MongoContext;

public interface IShListMongoContext
{
    IMongoCollection<TDocument> GetShoppingListCollection<TDocument>();
}