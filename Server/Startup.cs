using CalculatorTest.Server.Extensions;
using CalculatorTest.Server.Services;
using ProtoBuf.Grpc.Server;

namespace CalculatorTest.Server;

internal sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddCodeFirstGrpc();
        services.AddRemoteServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        
        app.UseRouting();
        
        app.UseGrpcWeb(new GrpcWebOptions
        {
            DefaultEnabled = true
        });
        app.UseCors();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapGrpcService<CalculatorService>();
                endpoints.MapFallbackToFile("index.html");
            });
    }
}