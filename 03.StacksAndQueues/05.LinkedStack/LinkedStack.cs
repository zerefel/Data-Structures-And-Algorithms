using System;
using System.Xml;

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public LinkedStack()
    {
        this.firstNode = null;
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count == 0)
        {
            this.firstNode = new Node<T>(element);
        }
        else
        {
            var tempNode = new Node<T>(element);

            tempNode.NextNode = firstNode;
            firstNode = tempNode;
        }

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is Empty!");
        }

        var node = this.firstNode;

        this.firstNode = this.firstNode.NextNode;
        this.Count--;

        return node.Value;
    }

    public T[] ToArray()
    {
        var returnArray = new T[this.Count];

        Node<T> tempNode = this.firstNode;

        for (int i = 0; i < this.Count; i++)
        {
            returnArray[i] = tempNode.Value;
            tempNode = tempNode.NextNode;
        }

        return returnArray;
    }

    private class Node<T>
    {
        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }
        
        public Node<T> NextNode { get; set; }

        public T Value { get; set; }
    }
}