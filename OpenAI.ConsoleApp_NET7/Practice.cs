using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;

namespace OpenAI.ConsoleApp_NET7
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

                var completionResult = await _openAIService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                    {
                       ChatMessage.FromUser(Console.ReadLine()),
                    },
                    Model = Models.ChatGpt3_5Turbo,
                    MaxTokens = 500//optional
                });

                if (completionResult.Successful)
                {
                    Console.WriteLine(completionResult.Choices.First().Message.Content);
                }
                else
                {
                    Console.WriteLine($"{completionResult.Error.Message}");
                }


                //var completionResult = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest
                //{
                //    Prompt = Console.ReadLine(),
                //    Model = "gpt-3.5-turbo-instruct",
                //    MaxTokens = 500 //optional
                //});

                //if (completionResult.Successful)
                //{
                //    Console.WriteLine(completionResult.Choices.First().Text);
                //}
                //else
                //{
                //    Console.WriteLine($"{completionResult.Error.Message}");
                //}
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
                    Size = "256x256",
                });

                if (imageResult.Successful)
                {
                    Console.WriteLine(imageResult.Results.First().Url);
                    Console.WriteLine(imageResult.Results.First().B64);
                }
            }
        }
    }
}
