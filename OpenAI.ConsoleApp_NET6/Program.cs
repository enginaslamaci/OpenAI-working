using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenAI.ConsoleApp_NET6;
using OpenAI.Net;

internal class Program
{
    static async Task Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((builder, services) =>
        {
            services.AddOpenAIServices(options =>
            {
                options.ApiKey = "your_api_key";
            });
            services.AddSingleton<Practice>();
        })
        .Build();

        var practice = host.Services.GetService<Practice>();
        await practice!.CompletionTest();
        //await practice!.ImageTest();

        await host.RunAsync();
    }
}