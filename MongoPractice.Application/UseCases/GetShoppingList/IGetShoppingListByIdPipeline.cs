using MongoPractice.Domain.Aggregates;

namespace MongoPractice.Application.UseCases.GetShoppingList;

public interface IGetShoppingListByIdPipeline
{
    Task<Either<Error, ShList>> Process(Guid id);
}