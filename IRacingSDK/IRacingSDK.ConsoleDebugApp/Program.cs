using IRacingSDK.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IRacingSDK.ConsoleDebugApp;

internal class Program
{
    static readonly ManualResetEvent _quitEvent = new(false);
    private static IRacingSDKWrapper? _wrapper;

    static void Main(string[] args)
    {
        IServiceProvider serviceProvider = ConfigureServices();

        _wrapper = serviceProvider.GetRequiredService<IRacingSDKWrapper>();

        Console.CancelKeyPress += (sender, eArgs) =>
        {
            _quitEvent.Set();
            eArgs.Cancel = true;
        };
                
        try
        {
            _wrapper.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        _quitEvent.WaitOne();

        _wrapper.Stop();



    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection().AddIRacingSDK();

        return services.BuildServiceProvider();
    }
}
