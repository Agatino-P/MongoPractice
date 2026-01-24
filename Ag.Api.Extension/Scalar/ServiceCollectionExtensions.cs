using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Ag.Api.Extension.Scalar;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IApiVersioningBuilder AgAddApiVersioning()
        {
            IApiVersioningBuilder apiVersioningBuilder = services.AddApiVersioning(options =>
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
            return apiVersioningBuilder;
        }
    }
}