using System;

class Program
{
    // Exceed the requirements:
    // - Check Random action not select words already hidden.
    // - "_" = number of letters in word.

    static void Main(string[] args)
    {
        string originalText = "Even though I walk through the darkest valley, I will fear no evil, for you are with me; your rod and your staff, they comfort me.";
        Reference reference = new Reference("Psalm", 23, 4);
        Scripture scripture = new Scripture (reference, originalText);
        startInterface(scripture);
    }

    static void startInterface(Scripture scripture)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplay());
            Console.WriteLine();

            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();
            if (input == "quit" || scripture.IsCompletelyHidden())
            {
                break;
            }
        
            scripture.HideRandomWords(2);
        }
    }
}