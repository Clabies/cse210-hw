using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        Console.WriteLine("Displaying the information, wait...");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        Console.WriteLine("Saving your file ...");
        using (StreamWriter storedfile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                storedfile.WriteLine($"\"{entry._promptText}\",\"{entry._entryText}\",\"{entry._date}\"");
            }
        }
        Console.WriteLine("Your file is saved!");
    }

    public void LoadFromFile(string file)
    {
        Console.WriteLine("Loading your file ...");
        string[] toLoadEntry;
        string[] AllLinesInFile = File.ReadAllLines(file);

        foreach (string lineInFile in AllLinesInFile)
        {
            toLoadEntry = SplitLineForArray(lineInFile);
            Entry entryForJournal = new Entry(toLoadEntry[0], toLoadEntry[1], toLoadEntry[2]);
            _entries.Add(entryForJournal);
        }
        Console.WriteLine("Your file is now Loaded it!");
    }

    private string[] SplitLineForArray(string lineInFile)
    {
        List<string> resultList = new List<string>();
        bool inQuotes = false;
        int firstIndex = 0;

        for (int i = 0; i < lineInFile.Length; i++)
        {
            if (lineInFile[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (lineInFile[i] == ',' && !inQuotes)
            {
                resultList.Add(lineInFile.Substring(firstIndex, i - firstIndex));
                firstIndex = i + 1;
            }
        }

        resultList.Add(lineInFile.Substring(firstIndex));

        for (int i = 0; i < resultList.Count; i++)
        {
            resultList[i] = resultList[i].Trim('"');
        }

        return resultList.ToArray();
    }
}