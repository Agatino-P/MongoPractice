using Ag.Api.Extension.Scalar;
using MongoPractice.Api.EndpointHandlers;
using MongoPractice.ServiceDefaults;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddOpenApi();
builder.Services.AgAddApiVersioning();

builder.Services.AddShoppingListHandlers();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AgAddScalar();
}

app.UseHttpsRedirection();

app.MapAllEndpoints();

app.Run();