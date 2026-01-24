using Ag.Api.Extension.Scalar;
using MongoPractice.Api.EndpointHandlers;
using MongoPractice.Application.UseCases.ServiceExtensions;
using MongoPractice.ServiceDefaults;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddOpenApi();
builder.Services.AgAddApiVersioning();

builder.Services.AddShoppingListHandlers();

builder.Services.AddUseCasePipelines();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AgAddScalar();
}

app.UseHttpsRedirection();

app.MapAllEndpoints();

app.Run();