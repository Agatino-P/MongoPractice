using MongoPractice.Contracts.Read.V1.Views;

namespace MogoPractice.Wasm.Services;

    public interface IApiService
    {
        Task<IEnumerable<ShListSummaryViewV1>> GetShoppingLists();
    }