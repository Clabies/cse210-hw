using System;

class Program
{
    // Exceed the requirements:
    // - Handle invalid choice in "UserInterface()"  
    // - Save and load in .csv file 
    // could be opened in Excel (quotation and commas check)

    static Journal journal = new Journal();

    static void Main(string[] args)
    {
        while (true)
        {
            int numberChoice = ApplicationInterface();

            if (numberChoice == 5)
            {
                break;
            }
            else
            {
                PerformAction(numberChoice);
            }
        }
    }

    static public int ApplicationInterface()
    {
        Console.WriteLine("""
        Please select one of the following choices:
        1. Write
        2. Display
        3. Load
        4. Save
        5. Quit
        """);

        Console.Write("What would you like to do? ");
        return int.Parse(Console.ReadLine());
    }

    static void PerformAction(int choice)
    {
        switch (choice)
        {
            case 1:
                WriteEntry();
                break;
            case 2:
                journal.DisplayAll();
                break;
            case 3:
                LoadByNameFile();
                break;
            case 4:
                SaveNamedFile();
                break;
            default:
                Console.WriteLine("Invalid choice. Please select again.");
                break;
        }
    }

    static void WriteEntry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string displayGenerated = promptGenerator.GetRandomPrompt();
        Console.WriteLine(displayGenerated);

        Console.Write("> ");
        string answerUser = Console.ReadLine();

        Entry entry = new Entry(displayGenerated, answerUser);

        journal.AddEntry(entry);
    }

    static void SaveNamedFile()
    {
        Console.Write("What is the file?  ");
        string toSave = Console.ReadLine();
        journal.SaveToFile(toSave);
    }

    static void LoadByNameFile()
    {
        Console.Write("What is the file?  ");
        string toLoad = Console.ReadLine();
        journal.LoadFromFile(toLoad);
    }
}