using Microsoft.AspNetCore.Mvc;

namespace MongoPractice.Application.UseCases.GetShoppingList;

public interface IGetShoppingListByIdPipeline
{
    Task<Either<Error, ShList>> Process(Guid id);
}