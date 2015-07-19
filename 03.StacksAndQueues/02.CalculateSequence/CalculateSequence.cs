using System;
using System.Collections.Generic;

class CalculateSequence
{
    static void Main()
    {
        Queue<int> numbersQueue = new Queue<int>();
        int inputNum = int.Parse(Console.ReadLine());

        int membersCount = 50;

        numbersQueue.Enqueue(inputNum);
        int currentNumber;

        for (int i = 0; i < membersCount; i++)
        {
            currentNumber = numbersQueue.Dequeue();
            Console.Write(currentNumber + " ");
            numbersQueue.Enqueue(currentNumber + 1);
            numbersQueue.Enqueue(currentNumber * 2 + 1);
            numbersQueue.Enqueue(currentNumber + 2);
        }

    }
}