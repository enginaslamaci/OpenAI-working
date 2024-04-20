using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels.ImageResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenAI.ConsoleApp_NET6_2
{
    public class Practice
    {
        private readonly IOpenAIService _openAIService;

        public Practice(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task CompletionTest()
        {
            while (true)
            {
                Console.Write(">>");

                var completionResult = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest
                {
                    Prompt = Console.ReadLine(),
                    Model = Models.TextDavinciV3,
                    //Model = "gpt-3.5-turbo-instruct",
                    MaxTokens = 500 //optional
                });

                if (completionResult.Successful)
                {
                    Console.WriteLine(completionResult.Choices.First().Text);
                }
                else
                {
                    Console.WriteLine($"{completionResult.Error.Message}");
                }
            }
        }


        public async Task ImageTest()
        {
            while (true)
            {
                Console.Write(">>");

                var imageResult = await _openAIService.Image.CreateImage(new ImageCreateRequest
                {
                    Prompt = Console.ReadLine(),
                    N = 1,
                    Size = StaticValues.ImageStatics.Size.Size256,
                });

                if (imageResult.Successful)
                {
                    Console.WriteLine(imageResult.Results.First().Url);
                    Console.WriteLine(imageResult.Results.First().B64);
                }

                //////////////////////////////////////////////////////////////////

                #region Dall-E-3
                //var imageRequest = new ImageRequest() { model = "dall-e-3", prompt = "green", n = 1, size = "1792x1024" };
                //using (var client = new HttpClient())
                //{
                //    client.DefaultRequestHeaders.Clear();
                //    client.DefaultRequestHeaders.Authorization =
                //         new AuthenticationHeaderValue("Bearer", "your_api_key");
                //    var Message = await client.
                //          PostAsync("https://api.openai.com/v1/images/generations",
                //          new StringContent(JsonSerializer.Serialize(imageRequest),
                //          Encoding.UTF8, "application/json"));

                //    if (Message.IsSuccessStatusCode)
                //    {
                //        var content = await Message.Content.ReadAsStringAsync();
                //        var resp = JsonSerializer.Deserialize<ResponseModel>(content);
                //    }
                //}
                #endregion

            }
        }

        public class ImageRequest
        {
            public string model { get; set; }
            public string prompt { get; set; }
            public int n { get; set; }
            public string size { get; set; }
        }

        public class Link
        {
            public string? url { get; set; }
        }

        // model for the DALL E api response
        public class ResponseModel
        {
            public long created { get; set; }
            public List<Link>? data { get; set; }
        }

    }
}
