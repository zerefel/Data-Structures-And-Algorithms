using System;

class LinkedStackMain
{
    static void Main()
    {
        LinkedStack<int> linkedStack = new LinkedStack<int>();

        linkedStack.Push(5);
        linkedStack.Push(7);
        linkedStack.Push(6);


        Console.WriteLine(linkedStack.Pop());
        Console.WriteLine(linkedStack.Pop());

        linkedStack.Push(1);
        linkedStack.Push(2);

        Console.WriteLine(linkedStack.Pop());
        Console.WriteLine(linkedStack.Pop());
    }
}
