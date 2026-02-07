using MongoDB.Driver;

namespace MongoPractice.Infrastructure.MongoContext;

public class ShListMongoContext : IShListMongoContext
{
    private const string _shoppingListDbName = "shopping_list_db";
    private const string _shoppingListsCollectionName = "shopping_lists";
    
    private readonly IMongoDatabase _database;

    public ShListMongoContext(string connectionString)
    {
        MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);

        IMongoClient client = new MongoClient(settings);
        _database = client.GetDatabase(_shoppingListDbName);
    }

    public IMongoCollection<TDocument> GetShoppingListCollection<TDocument>() =>
        _database.GetCollection<TDocument>(_shoppingListsCollectionName);
}