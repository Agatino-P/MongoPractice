using MongoPractice.Contracts.Read.V1.Views;

namespace MongoPractice.Infrastructure.Database.DataSources.GetShoppingListDataSource;

public class ShoppingListDataSource : IShoppingListDataSource
{
    public async Task<Either<Error, ShListViewV1>> GetDetail(Guid id)
    {
        return Error.New("Not yet implemented- JUST TO COMPILE");
    }
}