using Microsoft.AspNetCore.Components;
using MongoPractice.Contracts.Read.V1.Views;

namespace MongoPractice.Wasm.Components;

public partial class ShItemComponent : ComponentBase
{
    [Parameter]
    public ShItemViewV1 ShItem { get; set; } = default!;
}