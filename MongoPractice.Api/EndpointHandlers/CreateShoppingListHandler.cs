using Microsoft.AspNetCore.Mvc;
using MongoPractice.Application.UseCases.CreateShoppingList;
using MongoPractice.Application.UseCases.GetShoppingList;
using MongoPractice.Contracts.V1.Dtos;
using MongoPractice.Domain;

namespace MongoPractice.Api.EndpointHandlers;

public class CreateShoppingListHandler
{
    private readonly ICreateShoppingListPipeline _createShoppingListPipeline;
    private readonly ILogger<CreateShoppingListHandler> _logger;

    public CreateShoppingListHandler(
        ICreateShoppingListPipeline  createShoppingListPipeline,
        ILogger<CreateShoppingListHandler> logger)
    {
        _createShoppingListPipeline = createShoppingListPipeline;
        _logger = logger;
    }

    public async Task<IResult> Process(CreateShListDtoV1 dto)
    {
        _logger.LogInformation("Getting shopping list...");
        var pipelineInput = ToPipelineInput(dto);
        
        EitherAsync<ProblemDetails, Unit> eitherAsync = _createShoppingListPipeline.Process(pipelineInput).ToAsync()
            .MapLeft(toProblemDetails);

        var either=await eitherAsync;
        
        return either.Match<IResult>(
            shList => Results.Ok(),
            pd => Results.Json(data: pd, statusCode: (pd.Status ?? StatusCodes.Status500InternalServerError))
        );
    }
    
    private CreateShoppingListPipelineInput ToPipelineInput(CreateShListDtoV1 dto)
        => new CreateShoppingListPipelineInput(dto.Id, dto.Name);
    
    private static ProblemDetails toProblemDetails(Error error)
    => new ProblemDetails(){Detail =  error.Message};
}

