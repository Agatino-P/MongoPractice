using MongoPractice.Contracts.Read.V1.Views;

namespace MongoPractice.Wasm.Services;

    public interface IApiService
    {
        Task<IEnumerable<ShListSummaryViewV1>> GetShoppingLists();
        Task<ShListViewV1?> GetShoppingList(Guid id);
    }