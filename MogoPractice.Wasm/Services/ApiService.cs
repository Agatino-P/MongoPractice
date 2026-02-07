using MongoPractice.Contracts.Read.V1.Views;
using System.Net.Http.Json;

namespace MogoPractice.Wasm.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiService> _logger;

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;

    }

    public async Task<IEnumerable<ShListViewV1>> GetShoppingLists()
    {
        var shLists=
            await _httpClient.GetFromJsonAsync<IEnumerable<ShListViewV1>>("/api/v1/shopping-list") ?? [];
        return shLists;
    }
}