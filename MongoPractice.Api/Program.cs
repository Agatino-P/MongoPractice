using Ag.Api.Extension.Scalar;
using MongoPractice.Api.EndpointHandlers.RoutingExtensions;
using MongoPractice.Application.UseCases.ServiceExtensions;
using MongoPractice.Infrastructure.Database.Repositories;
using MongoPractice.Infrastructure.ServiceExtensions;
using MongoPractice.ServiceDefaults;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddMongoServices(ResourceNames.MongoDb);

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