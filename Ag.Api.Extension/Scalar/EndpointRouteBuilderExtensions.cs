using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Scalar.AspNetCore;

namespace Ag.Api.Extension.Scalar;

public static class EndpointRouteBuilderExtensions
{
    extension(IEndpointRouteBuilder app)
    {
        public void AgAddScalar()
        {
            // 2. REQUIRED: Generates the JSON file at /openapi/v1.json
            app.MapOpenApi();

            // 3. Serves the UI at /scalar/v1
            app.MapScalarApiReference();
    
            // Optional: Redirect root to Scalar
            app.MapGet("/", () => Results.Redirect("/scalar/v1"));        }
    }
}