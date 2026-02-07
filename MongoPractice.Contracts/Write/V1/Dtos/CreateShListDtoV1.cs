namespace MongoPractice.Contracts.Write.V1.Dtos;

public record CreateShListDtoV1(Guid Id, string Name, IEnumerable <CreateShItemDtoV1> shItems);

public record CreateShItemDtoV1(Guid Id, string Name, int Quantity);
