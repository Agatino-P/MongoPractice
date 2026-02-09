using MongoPractice.Contracts.Read.V1.Views;
using System.Net.Http.Json;

namespace MongoPractice.Wasm.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiService> _logger;

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;

    }

    public async Task<IEnumerable<ShListSummaryViewV1>> GetShoppingLists()
    {
        IEnumerable<ShListSummaryViewV1> shListSummaryViews=
            await _httpClient.GetFromJsonAsync<IEnumerable<ShListSummaryViewV1>>("/api/v1/shopping-list") ?? [];
        return shListSummaryViews;
    }
}