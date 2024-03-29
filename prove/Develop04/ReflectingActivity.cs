using System;

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _reflectionQuestions = new List<string>();

    public ReflectingActivity(){
        _activityName = "Reflecting";
        _activityDescription = """
        This activity will help you reflect on times in your life when you 
        have shown strength and resilience. This will help you recognize the 
        power you have and how you can use it in other aspects of your life.
        """;
        LoadPrompts();
        LoadReflectionQuestions();    
    }

    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        _activityDuration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);


        while (DateTime.Now < endTime)
        {
            DisplayReflectionQuestion();
            ShowSpinner(5);
            Console.WriteLine();
        }

        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine();
        DisplayEndingMessage();
        ShowSpinner(4);
        Console.Clear();
    }

    public string GetRandomPrompt(){
        Random random = new Random();
        int indexElement = random.Next(_prompts.Count);
        return _prompts[indexElement];
    }

    public string GetRandomReflectionQuestion(){
        Random random = new Random();
        if (_reflectionQuestions.Count == 0)
        {
            LoadReflectionQuestions();
        }
        int indexElement = random.Next(_reflectionQuestions.Count);
        string elementSelected = _reflectionQuestions[indexElement];
        // elements selected randomly do not repeat
        _reflectionQuestions.RemoveAt(indexElement);
        return elementSelected;
    }

    public void DisplayPrompt(){
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }

    public void DisplayReflectionQuestion(){
        Console.Write($"> {GetRandomReflectionQuestion()} ");
    }

    private void LoadPrompts(){
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
    }

    private void LoadReflectionQuestions()
    {
        _reflectionQuestions.Add("Why was this experience meaningful to you?");
        _reflectionQuestions.Add("Have you ever done anything like this before?");
        _reflectionQuestions.Add("How did you get started?");
        _reflectionQuestions.Add("How did you feel when it was complete?");
        _reflectionQuestions.Add("What made this time different than other times when you were not as successful?");
        _reflectionQuestions.Add("What is your favorite thing about this experience?");
        _reflectionQuestions.Add("What could you learn from this experience that applies to other situations?");
        _reflectionQuestions.Add("What did you learn about yourself through this experience?");
        _reflectionQuestions.Add("How can you keep this experience in mind in the future?");
    }
}