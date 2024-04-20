using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenAI.ConsoleApp_NET8;


using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<Practice>();
    })
    .Build();

var practice = host.Services.GetService<Practice>();
await practice!.CompletionTest();
//await practice!.ImageTest();

await host.RunAsync();
