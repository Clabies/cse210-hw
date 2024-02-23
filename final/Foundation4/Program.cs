using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        var activities = new List<Activity>
        {
            new Running(new DateTime(2024, 11, 3), 30, 3.0),
            new Running(new DateTime(2024, 11, 3), 30, 4.8),
            new StationaryBicycle(new DateTime(2024, 11, 5), 45, 15.0),
            new Swimming(new DateTime(2024, 11, 6), 60, 20),
        };

        // Display summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}