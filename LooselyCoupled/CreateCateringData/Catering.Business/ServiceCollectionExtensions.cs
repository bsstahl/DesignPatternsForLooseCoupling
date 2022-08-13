using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catering.Business;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseCateringBusinessEngine(this IServiceCollection services)
    {
        return services
            .AddTransient<IOrchestrationEngine, Engine>();
    }
}
