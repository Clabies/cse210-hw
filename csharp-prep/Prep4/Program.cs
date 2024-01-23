using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int userNumber = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        int max = numbers[0];
        int minPositive = int.MaxValue;

        foreach (int number in numbers)
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
            if (number > 0 && number < minPositive)
            {
                minPositive = number;
            }
        }

        Console.WriteLine("The sum is: " + sum);

        double average = ((double)sum) / numbers.Count;
        Console.WriteLine("The average is: " + average);

        Console.WriteLine("The largest number is: " + max);

        if (minPositive != int.MaxValue)
        {
            Console.WriteLine("The smallest positive number is: " + minPositive);
        }

        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}