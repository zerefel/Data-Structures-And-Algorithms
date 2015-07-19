using System;

public class LinkedQueue<T>
{
    private QueueNode<T> headNode;
    private QueueNode<T> tailNode;

    public LinkedQueue()
    {
        this.headNode = null;
        this.tailNode = null;
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.headNode = new QueueNode<T>(element);
            this.tailNode = this.headNode;
        }
        else
        {
            QueueNode<T> newNode = new QueueNode<T>(element, this.tailNode);
            this.tailNode.NextNode = newNode;
            this.tailNode = newNode;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot dequeue from empty queue.");
        }

        var elementValue = this.headNode.Value;

        this.headNode = this.headNode.NextNode;

        this.Count--;

        if (this.Count > 0)
        {
            this.headNode.PrevNode = null;            
        }

        return elementValue;
    }

    public T[] ToArray()
    {
        var queueArray = new T[this.Count];
        var tempNode = this.headNode;

        for (int i = 0; i < this.Count; i++)
        {
            queueArray[i] = tempNode.Value;
            tempNode = tempNode.NextNode;
        }

        return queueArray;
    }

    private class QueueNode<T>
    {
        public QueueNode(T value, QueueNode<T> prevNode = null, QueueNode<T> nextNode = null)
        {
            this.NextNode = nextNode;
            this.PrevNode = prevNode;
            this.Value = value;
        }

        public T Value { get; set; }

        public QueueNode<T> PrevNode { get; set; }

        public QueueNode<T> NextNode { get; set; }
    }
}
