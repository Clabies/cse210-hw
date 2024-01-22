using System;
using System.Reflection.Metadata;
using System.Security.AccessControl;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What's your grade percentage?");
        int gradePercentage = int.Parse(Console.ReadLine());
        string letter;
        string signal = "";

        int rest = gradePercentage%10;

        if (rest>=7)
        {
            signal = "+";
        }
        else if (rest<3)
        {
            signal = "-";
        }

        if (gradePercentage>=90)
        {
            if (rest<3)
            {
                letter = "A" + signal;
            }
            else
            {
                letter = "A";
            }
        }
        else if (gradePercentage>=80)
        {
            letter = "B" + signal;
        }
        else if  (gradePercentage>=70)
        {
            letter = "C" + signal;
        }
        else if  (gradePercentage>=60)
        {
            letter = "D" + signal;
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");
        
        if (gradePercentage>=70)
        {
            Console.WriteLine("Congratulations, you passed the course :)");
        }
        else
        {
            Console.WriteLine("Keep trying, good luck on the next one!");
        }

    }
}