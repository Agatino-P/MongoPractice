using Microsoft.AspNetCore.Components;
using MogoPractice.Wasm.Services;
using MongoPractice.Contracts.Read.V1.Views;

namespace MogoPractice.Wasm.Pages;

public partial class ShListsPage
{
    [Inject]
    public required IApiService ApiService { get; set; }
    
    protected IEnumerable<ShListViewV1>? ShListViews { get; private set; }
    
    protected override async Task OnInitializedAsync()
    {
        ShListViews = await ApiService.GetShoppingLists();
    }
}