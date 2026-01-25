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
            app.MapOpenApi();

            app.MapScalarApiReference();

            app.MapGet("/", () => Results.Redirect("/scalar/v1"))
                .ExcludeFromDescription();
        }
    }
}