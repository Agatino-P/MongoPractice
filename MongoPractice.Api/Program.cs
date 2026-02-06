using Ag.Api.Extension.Scalar;
using MongoPractice.Api.EndpointHandlers;
using MongoPractice.Api.EndpointHandlers.Extensions;
using MongoPractice.Application.UseCases.ServiceExtensions;
using MongoPractice.Infrastructure.Database;
using MongoPractice.ServiceDefaults;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.AddMongoDBClient(ResourceNames.MongoDb);
builder.Services.AddScoped<IShListRepository, ShListRepository>();

builder.Services.AddOpenApi();
builder.Services.AgAddApiVersioning();

builder.Services.AddShoppingListHandlers();

builder.Services.AddUseCasePipelines();

const string allowSpecificOriginsCorsPolicyName = "AllowSpecificOriginsCorsPolicy";
string allowSpecificOriginsCorsSetting =
    builder.Configuration["AllowedCorsOrigins"] ??
    throw new InvalidOperationException("AllowedCorsOrigins is missing in appsettings.");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOriginsCorsPolicyName,
        policy =>
        {
            policy.WithOrigins(allowSpecificOriginsCorsSetting)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AgAddScalar();
}

app.UseHttpsRedirection();

app.UseCors(allowSpecificOriginsCorsPolicyName);
app.MapAllEndpoints();

app.Run();