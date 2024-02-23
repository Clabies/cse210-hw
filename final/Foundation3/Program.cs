using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        var address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        var address2 = new Address("456 Elm St", "Othertown", "NY", "USA");
        var address3 = new Address("789 Oak St", "Somewhere", "BC", "Canada");

        // Create events
        var lecture = new Lecture("Tech Talk", "A talk about new technologies", new DateTime(2024, 2, 28), new TimeSpan(18, 0, 0), address1, "John Doe", 50);
        var reception = new Reception("Networking Mixer", "A social gathering for professionals", new DateTime(2024, 3, 15), new TimeSpan(19, 0, 0), address2, "rsvp@example.com");
        var outdoorGathering = new OutdoorGathering("Picnic in the Park", "Enjoy a day outdoors with friends", new DateTime(2024, 4, 20), new TimeSpan(12, 0, 0), address3, "Sunny");

        // Display marketing messages
        Console.WriteLine("=== Lecture ===");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine("\n=== Reception ===");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine("\n=== Outdoor Gathering ===");
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}