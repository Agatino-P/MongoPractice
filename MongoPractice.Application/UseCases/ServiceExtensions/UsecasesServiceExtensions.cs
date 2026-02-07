using Microsoft.Extensions.DependencyInjection;
using MongoPractice.Application.UseCases.CreateShoppingList;

namespace MongoPractice.Application.UseCases.ServiceExtensions;

public static  class UseCasesServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUseCasePipelines()
        {
            services.AddScoped<ICreateShoppingListPipeline, CreateShoppingListPipeline>();

            return services;
        }
    }
    
}