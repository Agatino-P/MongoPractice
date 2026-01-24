using Asp.Versioning;
using Asp.Versioning.Builder;
using MongoPractice.ServiceDefaults;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddOpenApi();

builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1.0);
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // 2. REQUIRED: Generates the JSON file at /openapi/v1.json
    app.MapOpenApi();

    // 3. Serves the UI at /scalar/v1
    app.MapScalarApiReference();
    
    // Optional: Redirect root to Scalar
    app.MapGet("/", () => Results.Redirect("/scalar/v1"));
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