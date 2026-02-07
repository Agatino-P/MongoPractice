using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoPractice.Infrastructure.Database.DataSources.GetShoppingListDataSource;
using MongoPractice.Infrastructure.Database.DataSources.GetSummaries;
using MongoPractice.Infrastructure.Database.Repositories;
using MongoPractice.Infrastructure.MongoContext;
using MongoPractice.ServiceDefaults;

namespace MongoPractice.Infrastructure.ServiceExtensions;

public static class MongoServiceCollectionExtensions
{
    public static IServiceCollection AddMongoServices(this IServiceCollection services, string mongodbConnectionStringKey)
    {
        services.AddSingleton<IShListMongoContext,ShListMongoContext>(sp =>
        {
            IConfiguration config = sp.GetRequiredService<IConfiguration>();
            string connectionString = config.GetConnectionString(ResourceNames.MongoConnection)!;
            
            return new ShListMongoContext(connectionString);
        });

        services.AddScoped<IShListRepository, ShListRepository>();
        
        services.AddScoped<IShListSummariesDataSource,ShListSummariesDataSource >();
        services.AddScoped<IShoppingListDataSource,ShoppingListDataSource >();
        
        return services;
    }
}