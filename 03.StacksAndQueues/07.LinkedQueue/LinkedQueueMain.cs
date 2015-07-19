class LinkedQueueMain
{
    static void Main()
    {
        LinkedQueue<int> linkedQueue = new LinkedQueue<int>();

        linkedQueue.Enqueue(2);
        linkedQueue.Enqueue(3);
        linkedQueue.Enqueue(5);
        linkedQueue.Enqueue(61);
        linkedQueue.Enqueue(57);

        linkedQueue.Dequeue();
        linkedQueue.Dequeue();
        linkedQueue.Dequeue();
    }
}