namespace sk_dev;

using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SemanticKernel.Connectors.OpenAI;

internal class PromptSettings
{
    internal static OpenAIPromptExecutionSettings OpenAIPromptSettings = new()
    {
        ChatSystemPrompt = "You are a helpful AI assistant.",
        Temperature = 0.2,
        //MaxTokens = 800,
        //TopP = 0.8,
        //FrequencyPenalty = 0,
        //PresencePenalty = 0,
        //StopSequences = new List<string> { "###" }
    };
}

