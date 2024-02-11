using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<string> _words = new List<string>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = ConvertToWordList(text);
    }

    public void HideRandomWords(int numberToHide)
    {
        int hiddenCount = 0;
        Random random = new Random();

        while (hiddenCount < numberToHide && _words.Any(word => !IsHidden(word)))
        {
            int randomIndex = random.Next(_words.Count);
            string selectedWord = _words[randomIndex];

            if (!IsHidden(selectedWord))
            {
                _words[randomIndex] = Underscores(selectedWord);
                hiddenCount++;
            }
        }
    }

    public string GetDisplay()
    {
        string reference = _reference.GetFormattedText();
        string text = string.Join(" ", _words);
        return $"{reference} {text}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(IsHidden);
    }

    private List<string> ConvertToWordList(string text)
    {
        return new List<string>(text.Split(' '));
    }

    private bool IsHidden(string word)
    {
        return word.StartsWith("_");
    }

    private string Underscores(string word)
    {
        int numberOfCharacters = word.Length;
        return new string('_', numberOfCharacters);
    }
}