namespace MongoPractice.Contracts.Read.V1.Views;

public record ShListViewV1(Guid Id, string Name, IEnumerable<ShItemViewV1> Items);