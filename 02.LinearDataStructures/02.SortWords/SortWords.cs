using System;
using System.Collections.Generic;

class SortWords
{
    static void Main()
    {
        List<string> wordsList = new List<string>();
        
        string input = Console.ReadLine();

        var inputWordsArray = input.Split(null);

        foreach (string word in inputWordsArray)
        {
            wordsList.Add(word);
        }

        wordsList.Sort();

        foreach (string word in wordsList)
        {
            Console.Write(word + " ");
        }

        Console.WriteLine();
    }
}

