using System;
using System.Collections;
class ListingActivity : Activity
{
    private int _responseCount;
    private List<string> _prompts = new List<string>();

    public ListingActivity() {
        _activityName = "Listing";
        _activityDescription = """
        This activity aims to encourage reflection on the positive aspects of your life. 
        You'll be invited to compile a comprehensive list of as many good things as possible 
        within a specific area.
        """;
        LoadPrompts();
    }

    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        _activityDuration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();

        Console.WriteLine("List as many responses you can do to the following prompt: ");
        Console.WriteLine();

        GetRandomPrompt();
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(9);
        Console.WriteLine();

        List<string> answerList = GetListFromUser();
        _responseCount = answerList.Count();
        Console.WriteLine($"You listed {_responseCount} items!");

        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine();

        DisplayEndingMessage();
        ShowSpinner(4);
        Console.Clear();
    }

    public void GetRandomPrompt(){
        Random random = new Random();
        int indexElement = random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[indexElement]} ---");
    }

    public List<string> GetListFromUser(){
        List<string> answerList = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            answerList.Add(input);
        }

        return answerList;
    }

    private void LoadPrompts() {
        _prompts.Add("Which individuals do you hold in high esteem?");
        _prompts.Add("What unique qualities and abilities do you possess?");
        _prompts.Add("Whom have you assisted or supported this week?");
        _prompts.Add("Can you recall a moment this month when you sensed the presence of the Holy Ghost?");
        _prompts.Add("Who do you admire as personal role models or inspirations?");
    }
}