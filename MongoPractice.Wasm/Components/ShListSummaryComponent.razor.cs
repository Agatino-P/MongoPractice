using Microsoft.AspNetCore.Components;
using MongoPractice.Contracts.Read.V1.Views;

namespace MongoPractice.Wasm.Components;

public partial class ShListSummaryComponent : ComponentBase
{
    [Parameter]
    public ShListSummaryViewV1 ShListSummary { get; set; } = default!;
}