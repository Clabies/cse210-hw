using System;

class Activity
{
    protected string _activityName;
    protected string _activityDescription;
    protected int _activityDuration;

    public Activity(){

    }

    public void DisplayStartingMessage(){
        Console.WriteLine($"Welcome to the {_activityName} Activity.");
        Console.WriteLine();
        Console.WriteLine(_activityDescription);
        Console.WriteLine();
        Console.Write("How many seconds, would you like for your session? ");
    }

    public void DisplayEndingMessage(){
        Console.WriteLine($"You have completed another {_activityDuration} seconds of the {_activityName} Activity");
    }

    public void ShowSpinner(int seconds){
        List<string> animations = new List<string>();
        animations.Add("|");
        animations.Add("/");
        animations.Add("—");
        animations.Add("\\");
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        
        while (DateTime.Now < endTime)
        {
            string symbol = animations[i];
            Console.Write(symbol);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i += 1;

            if (i >= animations.Count)
            {
                i = 0;                
            }
        }
    }

    public void ShowCountDown(int seconds){
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

}