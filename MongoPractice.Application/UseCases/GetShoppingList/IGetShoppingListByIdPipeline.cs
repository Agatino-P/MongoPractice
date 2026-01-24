using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using MongoPractice.Domain;

namespace MongoPractice.Application.UseCases.GetShoppingList;

public interface IGetShoppingListByIdPipeline
{
    Task<Either<ProblemDetails, ShList>> Process(Guid id);
}