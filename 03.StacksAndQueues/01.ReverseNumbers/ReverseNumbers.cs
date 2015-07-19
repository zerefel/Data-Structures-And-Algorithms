using System;
using System.Collections.Generic;

class ReverseNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        string[] strNumbersArr = input.Split(null);
        Stack<int> numbersStack = new Stack<int>();

        int parsedNumber;

        foreach (string num in strNumbersArr)
        {
            parsedNumber = int.Parse(num);
            numbersStack.Push(parsedNumber);
        }

        int poppedNumber;

        while (numbersStack.Count > 0)
        {
            poppedNumber = numbersStack.Pop();
            Console.Write(poppedNumber + " ");
        }
    }
}
