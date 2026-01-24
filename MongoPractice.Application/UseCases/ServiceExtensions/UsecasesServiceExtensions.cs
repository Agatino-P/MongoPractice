using Microsoft.Extensions.DependencyInjection;
using MongoPractice.Application.UseCases.GetShoppingList;

namespace MongoPractice.Application.UseCases.ServiceExtensions;

public static  class UseCasesServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUseCasePipelines()
        {
            services.AddScoped<IGetShoppingListByIdPipeline, GetShoppingListByIdPipeline>();

            return services;
        }
    }
    
}