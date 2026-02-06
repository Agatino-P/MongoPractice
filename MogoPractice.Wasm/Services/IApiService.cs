using MongoPractice.Contracts.V1.Views;

namespace MogoPractice.Wasm.Services;

    public interface IApiService
    {
        Task<IEnumerable<ShListViewV1>> GetShoppingLists();
    }