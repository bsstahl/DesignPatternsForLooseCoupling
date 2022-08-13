using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catering.Data.CateringEventLog;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseCateringEventLogRepository(this IServiceCollection services)
    {
        return services
            .AddTransient<ICateringEventWriteRepository, Repository>();
    }
}
