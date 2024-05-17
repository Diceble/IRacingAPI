using IRacingAPI.Abstractions;
using IRacingAPI.Extensions;
using IRacingAPI.Models.EventArguments;
using Microsoft.Extensions.DependencyInjection;

namespace IRacingSDK.ConsoleDebugApp;

internal class Program
{
    static readonly ManualResetEvent _quitEvent = new(false);
    private static IIRacingSDKWrapper? _wrapper;


    static void Main()
    {
        IServiceProvider serviceProvider = ConfigureServices;
        _wrapper = serviceProvider.GetRequiredService<IIRacingSDKWrapper>();

        CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        Console.CancelKeyPress += (sender, eArgs) =>
        {
            _quitEvent.Set();
            eArgs.Cancel = true;
        };
                
        try
        {
            _wrapper.Start(cancellationToken);
            _wrapper.TelemetryUpdated += OnTelemetryUpdated;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        _quitEvent.WaitOne();

        _wrapper.Stop();
    }

    private static IServiceProvider ConfigureServices
    {
        get
        {
            IServiceCollection services = new ServiceCollection().AddIRacingSDK();
            return services.BuildServiceProvider();
        }
    }

    private static void OnTelemetryUpdated(object? sender, TelemetryUpdatedEventArgs e)
    {
        Console.WriteLine("Telemetry updated");
    }
}
