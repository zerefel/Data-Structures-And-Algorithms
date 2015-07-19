using System;
using System.Collections.Generic;

class SumAndAverage
{
    static void Main()
    {
        List<int> integersList = new List<int>();
        int sum = 0;

        string input = Console.ReadLine();

        var inputNumsArray = input.Split(null);

        foreach (var num in inputNumsArray)
        {
            int parsedNum = int.Parse(num);
            integersList.Add(parsedNum);

            sum += parsedNum;
        }

        double average = (double)sum / (integersList.Count);

        Console.WriteLine("Sum={0}, Average={1}", sum, average);
    }
}
