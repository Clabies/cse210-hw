using System;

class Program
{
    static void Main(string[] args)
    {
        string originalText = "Even though I walk through the darkest valley, I will fear no evil, for you are with me; your rod and your staff, they comfort me.";
        Reference reference = new Reference("Psalm", 23, 4);
        Writing writing = new Writing(reference, originalText);
        RunInterface(writing);
    }

    static void RunInterface(Writing writing)
    {
        while (true)
        {
            Console.WriteLine(writing.GetVisualization());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input == "quit" || writing.IsFullyHidden())
            {
                break;
            }

            Console.Clear();
            writing.HideRandomWords(2);
        }
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int Verse { get; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
    }
}

class Writing
{
    private Reference _reference;
    private string _originalText;
    private string[] _words;
    private bool[] _hidden;

    public Writing(Reference reference, string originalText)
    {
        _reference = reference;
        _originalText = originalText;
        _words = originalText.Split(' ');
        _hidden = new bool[_words.Length];
    }

    public string GetVisualization()
    {
        string visualization = "";
        for (int i = 0; i < _words.Length; i++)
        {
            if (_hidden[i])
            {
                visualization += new string('_', _words[i].Length);
            }
            else
            {
                visualization += _words[i];
            }
            visualization += " ";
        }
        return visualization.Trim();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(_words.Length);
            if (!_hidden[index])
            {
                _hidden[index] = true;
            }
            else
            {
                i--;
            }
        }
    }

    public bool IsFullyHidden()
    {
        foreach (bool hide in _hidden)
        {
            if (!hide)
            {
                return false;
            }
        }
        return true;
    }
}