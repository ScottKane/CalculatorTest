using System.Runtime.CompilerServices;

namespace CalculatorTest.Server;

internal static class Program
{
    private static async Task Main() =>
        await Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(
                builder =>
                {
                    builder.UseStaticWebAssets();
                    builder.UseStartup<Startup>();
                })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
            })
            .Build()
            .RunAsync();
}
