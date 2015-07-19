using System;
using ArrayStack;

class ArrayStackMain
{
    static void Main()
    {
        // Some basic tests, covered more thoroughly in the unit tests project

        var arrayStack = new ArrayStack<int>(4);

        arrayStack.Push(1675474);
        arrayStack.Push(2);
        arrayStack.Push(3);
        arrayStack.Push(4);
        arrayStack.Push(5);
        arrayStack.Push(2);
        arrayStack.Push(1);
        arrayStack.Push(83);
        arrayStack.Push(92);
        arrayStack.Push(1520);

        Console.WriteLine(arrayStack.Count);

        var array = arrayStack.ToArray();
    }
}
