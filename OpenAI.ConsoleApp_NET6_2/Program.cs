using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenAI.ConsoleApp_NET6_2;
using OpenAI.Extensions;

internal class Program
{
    static async Task Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
            services.AddOpenAIService(settings => { settings.ApiKey = "your_api_key"; });
            services.AddSingleton<Practice>();
        })
        .Build();

        //var openAi = host.Services.GetService<IOpenAIService>()!;

        var practice = host.Services.GetService<Practice>();
        await practice!.CompletionTest();
        await practice!.ImageTest();

        await host.RunAsync();
    }
}