using CalculatorTest.Client;
using CalculatorTest.Shared;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using MudBlazor.ThemeManager;
using ProtoBuf.Grpc.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices(
    configuration =>
    {
        configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
        configuration.SnackbarConfiguration.HideTransitionDuration = 100;
        configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
        configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
        configuration.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        configuration.SnackbarConfiguration.ShowCloseIcon = false;
    });

using var channel = GrpcChannel.ForAddress(
    "https://localhost:5001",
    new GrpcChannelOptions { HttpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler()) });

builder.Services.AddSingleton<ThemeManagerTheme>();
builder.Services.AddSingleton(channel.CreateGrpcService<ISimpleCalculator>());

await builder.Build().RunAsync();
await channel.ShutdownAsync();