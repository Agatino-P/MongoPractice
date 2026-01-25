namespace MongoPractice.Application.UseCases.CreateShoppingList;

public interface ICreateShoppingListPipeline
{
    Task<Either<Error, Unit>> Process(CreateShoppingListPipelineInput pipelineInput);
}

public record CreateShoppingListPipelineInput(Guid Id, string Name);
