using MongoPractice.Contracts.Read.V1.Views;

namespace MongoPractice.Infrastructure.Database.DataSources.GetShoppingListDataSource;

public interface IShoppingListDataSource
{
    Task<Either<Error, ShListViewV1>> GetDetail(Guid id);
}