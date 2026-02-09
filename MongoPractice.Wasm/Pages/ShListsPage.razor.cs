using Microsoft.AspNetCore.Components;
using MongoPractice.Wasm.Services;
using MongoPractice.Contracts.Read.V1.Views;

namespace MongoPractice.Wasm.Pages;

public partial class ShListsPage
{
    [Inject]
    public required IApiService ApiService { get; set; }

    protected ShListSummaryViewV1[] ShListViews { get; private set; } = [];
    
    protected override async Task OnInitializedAsync()
    {
        ShListViews = (await ApiService.GetShoppingLists()).ToArray();
    }
}