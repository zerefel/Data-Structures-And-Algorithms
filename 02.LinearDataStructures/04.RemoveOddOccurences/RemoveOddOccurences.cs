using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class RemoveOddOccurences
{
    static void Main()
    {
        List<int> integersList = new List<int>();
        string input = Console.ReadLine();

        var inputNumsArray = input.Split(null);

        foreach (var num in inputNumsArray)
        {
            int parsedNum = int.Parse(num);
            integersList.Add(parsedNum);
        }

        integersList.Sort();
        foreach (int num in integersList)
        {
            Console.Write(num + " ");
        }
        int currentOccurences = 1;

        for (int i = 0; i < integersList.Count - 1; i++)
        {
            if (integersList[i] == integersList[i + 1])
            {
                currentOccurences++;
            }
            else
            {
                if (currentOccurences % 2 != 0)
                {
                    if (currentOccurences == 1)
                    {
                        integersList.RemoveAt(i);
                    }
                    else
                    {
                        integersList.RemoveRange(i - currentOccurences + 1, currentOccurences);
                        
                    }
                }
            }

        }

        Console.WriteLine();

        foreach (int num in integersList)
        {
            Console.Write(num + " ");
        }
    }
}
