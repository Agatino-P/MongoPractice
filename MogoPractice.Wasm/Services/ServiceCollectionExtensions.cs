namespace MogoPractice.Wasm.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IApiService, ApiService>();

        return services;
    }
    
}