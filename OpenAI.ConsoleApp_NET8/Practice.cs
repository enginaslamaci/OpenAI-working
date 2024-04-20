using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Images;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.ConsoleApp_NET8
{
    public class Practice
    {
        private readonly OpenAIAPI api;
        public Practice()
        {
            api = new OpenAIAPI(new APIAuthentication("your_api_key"));
        }


        public async Task CompletionTest()
        {
            while (true)
            {
                Console.Write(">>");

                var completionResult = await api.Completions.CreateCompletionAsync(new CompletionRequest(Console.ReadLine(), model: Model.Davinci));
                Console.WriteLine(completionResult.Completions.First().Text);
            }
        }

        public async Task ImageTest()
        {
            while (true)
            {
                Console.Write(">>");

                //DALL-E
                //var imageResult = await api.ImageGenerations.CreateImageAsync(new ImageGenerationRequest(Console.ReadLine(), 1, ImageSize._512));
                //Console.WriteLine(imageResult.Data[0].Url);

                //DALL-E-3
                var imageResult = await api.ImageGenerations.CreateImageAsync(new ImageGenerationRequest(Console.ReadLine(), OpenAI_API.Models.Model.DALLE3, ImageSize._1024x1792, "hd"));
                Console.WriteLine(imageResult.Data[0].Url);
            }
        }

    }
}
