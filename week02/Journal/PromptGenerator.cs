using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts = new List<string>
    {
        "Who was the most interesting person you met today?",
        "What was the best part of your day?",
        "What challenged you today and how did you respond?",
        "What is one small win you had today?",
        "Whats something you noticed or learned today?",
        "If you can redo one moment from today, what will it be?",
        "Where did you see a random act of kindness today?"
    };

    private readonly Random _random = new Random();

    public string GetRandomPrompt()
    {
        int i = _random.Next(_prompts.Count);
        return _prompts[i];
    }

}