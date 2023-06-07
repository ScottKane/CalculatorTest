using CalculatorTest.Server.Services;
using CalculatorTest.Shared;

namespace CalculatorTest.Server.Extensions;

public static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddRemoteServices(this IServiceCollection services) =>
        services.AddTransient<ISimpleCalculator, CalculatorService>();
}