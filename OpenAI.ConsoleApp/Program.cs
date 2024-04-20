using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenAI.ConsoleApp_NET7;
using OpenAI.Extensions;


using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => { settings.ApiKey = "your_api_key"; });
        services.AddSingleton<Practice>();
    })
    .Build();

var practice = host.Services.GetService<Practice>();
await practice!.CompletionTest();
//await practice!.ImageTest();

await host.RunAsync();
