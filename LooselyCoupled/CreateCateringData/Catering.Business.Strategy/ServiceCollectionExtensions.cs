using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catering.Business.Strategy;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseLunchtimeCateringStrategy(this IServiceCollection services)
    {
        return services
            .AddTransient<ICateringStrategy, LunchtimeCateringStrategy>();
    }
}
