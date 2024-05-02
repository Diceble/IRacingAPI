using IRacingAPI.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IRacingAPI.Extensions;
public static class IRacingSDKServiceCollectionExtension
{
    public static IServiceCollection AddIRacingSDK(this IServiceCollection services, Action<ILoggingBuilder>? configureLogging = null)
    {
        services.AddLogging(builder =>
        {
            if (configureLogging != null)
            {
                configureLogging?.Invoke(builder);
            }
            else
            {
                builder.AddConsole();
            }
        });

        services.AddScoped<IIRacingSDKWrapper, IRacingAPIWrapper>();
        services.AddScoped<IIRacingDataApi, IRacingApi>();

        return services;
    }
}
