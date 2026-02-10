using Microsoft.AspNetCore.Components;
using MongoPractice.Contracts.Read.V1.Views;
using MongoPractice.Wasm.Services;

namespace MongoPractice.Wasm.Pages;

public partial class ShListPage : ComponentBase
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    public IApiService ApiService { get; set; } = default!;

    public ShListViewV1? ShList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ShList = await ApiService.GetShoppingList(Id);
    }
}