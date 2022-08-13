using System;
using Catering.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catering.Data.MeetingFile;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseMeetingFileMeetingRepository(this IServiceCollection services, string filePath)
    {
        return services
            .AddTransient<IMeetingReadRepository>(s => new Repository(filePath));
    }
}
