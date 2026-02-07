using Ag.Api.Extension;
using MongoPractice.Application.UseCases.CreateShoppingList;
using MongoPractice.Contracts.Write.V1.Dtos;

namespace MongoPractice.Api.EndpointHandlers;

public partial class CreateShoppingListHandler
{
    private readonly ICreateShoppingListPipeline _createShoppingListPipeline;
    private readonly ILogger<CreateShoppingListHandler> _logger;

    public CreateShoppingListHandler(
        ICreateShoppingListPipeline createShoppingListPipeline,
        ILogger<CreateShoppingListHandler> logger)
    {
        _createShoppingListPipeline = createShoppingListPipeline;
        _logger = logger;
    }

    public async Task<IResult> Process(CreateShListDtoV1 dto)
    {
        _logger.LogMemberCalled();
        
        var pipelineInput = ToPipelineInput(dto);

        EitherAsync<ProblemDetails, Unit> eitherAsync = _createShoppingListPipeline.Process(pipelineInput).ToAsync()
            .MapLeft(toProblemDetails);

        var either = await eitherAsync;

        return either.Match<IResult>(
            shList => Results.Ok(),
            pd => Results.Json(data: pd, statusCode: (pd.Status ?? StatusCodes.Status500InternalServerError))
        );
    }

    private CreateShoppingListPipelineInput ToPipelineInput(CreateShListDtoV1 dto)
        => new CreateShoppingListPipelineInput(
            dto.Id,
            dto.Name,
            dto.shItems.Select(ToShitemInput).ToList());

    private CreateShoppingListPipelineInput.ShItem ToShitemInput(CreateShItemDtoV1 shItem)
        => new CreateShoppingListPipelineInput.ShItem
            (shItem.Id, shItem.Name, shItem.Quantity);

    private static ProblemDetails toProblemDetails(Error error)
        => new ProblemDetails() { Detail = error.Message };

    [LoggerMessage(LogLevel.Information, "{className}.{methodName} was called with payload {jsonPayload}")]
    partial void logMemberCalled(string className, string methodName, string jsonPayload);
}