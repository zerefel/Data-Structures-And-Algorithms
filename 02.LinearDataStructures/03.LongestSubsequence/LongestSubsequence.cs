using System;
using System.Collections.Generic;

class LongestSubsequence
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

        int longestSubsequence = 0;
        int currentSubsequence = 1;
        int longestSubsequenceStartIndex = 0;

        int listIterationCount = integersList.Count - 1;

        for (int i = 0; i < listIterationCount; i++)
        {
           

            if (integersList[i] == integersList[i + 1])
            {
                currentSubsequence++;
                
                if (i == listIterationCount - 1 && longestSubsequence < currentSubsequence)
                {
                    longestSubsequence = currentSubsequence;
                    longestSubsequenceStartIndex = i - longestSubsequence + 2;
                }
               
            }

            else
            {
                longestSubsequence = currentSubsequence;
                longestSubsequenceStartIndex = i - longestSubsequence + 1;
                currentSubsequence = 1;
            }

        }

        for (int i = longestSubsequenceStartIndex; i < longestSubsequenceStartIndex + longestSubsequence; i++)
        {
            Console.Write(integersList[i] + " ");
        }

       // Console.WriteLine(longestSubsequence + " " + longestSubsequenceStartIndex);
    }
}
