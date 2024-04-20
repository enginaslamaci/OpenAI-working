using OpenAI.Net;
using OpenAI.Net.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.ConsoleApp_NET6
{
    public class Practice
    {
        private readonly IOpenAIService _openAIService;

        public Practice(IOpenAIService openAIService)
        {
            _openAIService=openAIService;
        }

        public async Task CompletionTest()
        {
            while (true)
            {
                Console.Write(">>");

                //var response = await _openAIService.TextCompletion.Get(Console.ReadLine());

                var response = await _openAIService.TextCompletion.Get(Console.ReadLine(), (o) =>
                {
                    o.MaxTokens = 1024;
                    o.BestOf = 5;
                    o.Model = "gpt-3.5-turbo-1106";
                });

                if (response.IsSuccess)
                {
                    foreach (var result in response.Result!.Choices)
                    {
                        Console.WriteLine(result.Text);
                    }
                }
                else
                {
                    Console.WriteLine($"{response.ErrorMessage}");
                }

            }
        }


        public async Task ImageTest()
        {
            while (true)
            {
                Console.Write(">>");

                //var response = await _openAIService.Images.Generate(Console.ReadLine(), 3, "512x512");
                //var response = await _openAIService.Images.Generate(Console.ReadLine(), 3, "256x256");
                var response = await _openAIService.Images.Generate(Console.ReadLine(), 1, "1792x1024");

                if (response.IsSuccess)
                {
                    foreach (var result in response.Result!.Data)
                    {
                        Console.WriteLine(result.Url);
                    }
                }
                else
                {
                    Console.WriteLine($"{response.ErrorMessage}");
                }
            }
        }

    }
}
