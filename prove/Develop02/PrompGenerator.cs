using System;
using System.Collections.Generic;

class PromptGenerator
{
    public List<string> _prompts;

    public PromptGenerator(){
        _prompts = new List<string>();
        _prompts.Add("What's one thing you're grateful for today?");
        _prompts.Add("Describe a challenge you faced and how you overcame it.");
        _prompts.Add("What's a goal you're working towards?");
        _prompts.Add("Reflect on a recent act of kindness you witnessed or performed.");
        _prompts.Add("Share a memorable moment from today that brought you joy.");
        _prompts.Add("What's something new you learned today?");
        _prompts.Add("Write about a place you'd like to explore in the future.");
    }

    public string GetRandomPrompt(){
        Random random = new Random();
        int indexSelected = random.Next(0, _prompts.Count);
        return _prompts[indexSelected];
    }
}