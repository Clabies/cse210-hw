using System;
using System.Numerics;

class BreathingActivity : Activity
{
    public BreathingActivity(){
        _activityName = "Breathing";
        _activityDescription = """
        This activity is designed to aid relaxation by guiding you through slow, 
        deliberate breathing. Take the time to clear your mind and concentrate on 
        your breath, moving in and out gently.
        """;
    }

    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        _activityDuration = int.Parse(Console.ReadLine());

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine(); DisplayEndingMessage();
        ShowSpinner(4);
        Console.Clear();
    }
}