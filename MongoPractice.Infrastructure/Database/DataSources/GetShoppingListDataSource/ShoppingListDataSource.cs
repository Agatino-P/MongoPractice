using MongoDB.Driver;
using MongoPractice.Contracts.Read.V1.Views;
using MongoPractice.Infrastructure.Database.Entities;
using MongoPractice.Infrastructure.MongoContext;

namespace MongoPractice.Infrastructure.Database.DataSources.GetShoppingListDataSource;

public class ShoppingListDataSource : IShoppingListDataSource
{
    private readonly IMongoCollection<ShListEntity> _shListsCollection;

    public ShoppingListDataSource(IShListMongoContext shListMongoContext)
    {
        _shListsCollection = shListMongoContext.GetShoppingListCollection<ShListEntity>();
    }

    public async Task<Either<Error, ShListViewV1>> GetDetail(Guid id)
    {
        var entity = await _shListsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        if (entity == null)
        {
            return Error.New("Shopping list not found");
        }

        var items = entity.ShItems.Select(i => new ShItemViewV1(i.Id, i.Name, i.Quantity));
        return new ShListViewV1(entity.Id, entity.Name, items);
    }
}