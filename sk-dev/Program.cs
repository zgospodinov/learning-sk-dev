namespace sk_dev;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

internal class Program
{
    static async Task Main(string[] args)
    {
        var modelId = "gpt-4o";
        var apiKey = Environment.GetEnvironmentVariable("OAI_SK_DEV_KEY") ?? throw new InvalidOperationException("Please set the OAI_SK_DEV_KEY environment variable.");


        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(
            modelId: modelId,
            apiKey: apiKey);

        var kernel = builder.Build();
        var chatHistory = new ChatHistory();
        var chatCompletion = kernel.GetRequiredService<IChatCompletionService>();


        while (true)
        {
            Console.WriteLine("\nEnter your prompt:");
            var prompt = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(prompt)) break;

            chatHistory.AddUserMessage(prompt);

            var fullMessageResponse = string.Empty;
            await foreach (var message in chatCompletion.GetStreamingChatMessageContentsAsync(chatHistory, PromptSettings.OpenAIPromptSettings))
            {
                Console.Write(message.Content);
                fullMessageResponse += message.Content;
            }

            chatHistory.AddSystemMessage(fullMessageResponse);

        }

    }
}
