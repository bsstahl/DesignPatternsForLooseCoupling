using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingService;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseMeetingServiceMeetingRepository(this IServiceCollection services)
    {
        return services
            .AddTransient<IMeetingReadRepository, Service>();
    }
}
