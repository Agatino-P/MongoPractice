using MongoPractice.Domain.Aggregates;

namespace MongoPractice.Application.UseCases.CreateShoppingList;

public record CreateShoppingListPipelineInput(
    Guid Id, 
    string Name,
    List<CreateShoppingListPipelineInput.ShItem> ShItems)
{
    public record ShItem(Guid Id, string Name, int Quantity, ShItemStatus Status);
}