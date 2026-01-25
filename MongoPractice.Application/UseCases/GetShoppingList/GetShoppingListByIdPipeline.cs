using Microsoft.AspNetCore.Mvc;
using MongoPractice.Infrastructure.Database;

namespace MongoPractice.Application.UseCases.GetShoppingList;

public class GetShoppingListByIdPipeline : IGetShoppingListByIdPipeline
{
    private readonly IShListRepository _repository;
    private readonly ILogger<GetShoppingListByIdPipeline> _logger;

    public GetShoppingListByIdPipeline(IShListRepository repository, ILogger<GetShoppingListByIdPipeline> logger)
    {
        _repository = repository;
        _logger = logger;
    }
     public async Task<Either<Error, ShList>> Process(Guid id)
     {
         Either<Error, ShList> either = await _repository.GetById(id);         
         
         return either;
     }
}