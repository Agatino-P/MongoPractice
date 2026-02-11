using MongoPractice.Domain.Aggregates;
using MongoPractice.Infrastructure.Database.Repositories;

namespace MongoPractice.Application.UseCases.CreateShoppingList;

public class CreateShoppingListPipeline : ICreateShoppingListPipeline
{
    private readonly IShListRepository _repository;
    private readonly ILogger<CreateShoppingListPipeline> _logger;

    public CreateShoppingListPipeline(IShListRepository repository, ILogger<CreateShoppingListPipeline> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Either<Error, Unit>> Process(CreateShoppingListPipelineInput pipelineInput)
    {
        ShList shList = toShList(pipelineInput);
        Either<Error, Unit> either=await _repository.Add(shList);

        return either;
    }

    private static ShList toShList(CreateShoppingListPipelineInput pipelineInput)
        => new ShList(pipelineInput.Id, pipelineInput.Name, pipelineInput.ShItems.Select(toShItem));

    private static ShItem toShItem(CreateShoppingListPipelineInput.ShItem pipelineInputShItem)
        => new ShItem(pipelineInputShItem.Id, pipelineInputShItem.Name,pipelineInputShItem.Quantity, pipelineInputShItem.Status);


}