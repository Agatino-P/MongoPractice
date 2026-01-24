using Ag.Api.Extension.Scalar;
using Asp.Versioning;
using Asp.Versioning.Builder;
using MongoPractice.ServiceDefaults;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddOpenApi();

builder.Services.AgAddApiVersioning();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AgAddScalar();
}

app.UseHttpsRedirection();

ApiVersionSet apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1.0))
    .ReportApiVersions()
    .Build();

RouteGroupBuilder apiGroup = app.MapGroup("/api/v{version:apiVersion}")
    .WithApiVersionSet(apiVersionSet);

apiGroup.MapGet("/ShoppingList", () =>
{
    return Results.Ok("A ShoppingList");
});

app.Run();