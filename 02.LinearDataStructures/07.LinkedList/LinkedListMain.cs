using System;

class LinkedListMain
{
    static void Main()
    {
        LinkedList<int> testList = new LinkedList<int>();

        testList.Add(3); // index 0
        testList.Add(5); // index 1
        testList.Add(54); // index 2
        testList.Add(53); // index 3
        testList.Add(51); // index 4
        testList.Add(58); // index 5
        testList.Add(50); // index 6
        testList.Add(50); //index 7

        //testList.Remove(3);

        Console.WriteLine(testList.FirstIndexOf(50));
        Console.WriteLine(testList.LastIndexOf(50));
    }
}