using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using MongoPractice.Domain;

namespace MongoPractice.Application.UseCases.GetShoppingList;

public class GetShoppingListByIdPipeline : IGetShoppingListByIdPipeline
{
     public async Task<Either<ProblemDetails, ShList>> Process(Guid id)
     {
         await Task.CompletedTask;
         ShList shList = new ShList(id,id.ToString());
         return shList;
         
     }
}