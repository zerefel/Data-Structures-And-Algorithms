using System;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T> headNode;

    public LinkedList()
    {
        this.headNode = null;
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void Add(T element)
    {
        Node<T> tempNode = this.headNode;

        if (this.Count == 0)
        {
            this.headNode = new Node<T>(element);
        }
        else
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                tempNode = tempNode.NextNode;
            }

            tempNode.NextNode = new Node<T>(element);
        }

        Node<T> newNode = new Node<T>(element);

        this.Count++;
    }

    public void Remove(int index)
    {
        if (index >= this.Count || index < 0)
        {
            throw new IndexOutOfRangeException("No element found on that index.");
        }


        Node<T> tempNode = this.headNode;


        if (index == 0)
        {
            this.headNode = tempNode.NextNode;
        }
        else
        {   
            for (int i = 0; i < index - 1; i++)
            {
                tempNode = tempNode.NextNode;
            }

            tempNode.NextNode = tempNode.NextNode.NextNode;
        }

        this.Count--;
    }

    public int FirstIndexOf(T element)
    {
        Node<T> tempNode = this.headNode;

        if (tempNode.Value.Equals(element))
        {
            return 0;
        }


        for (int i = 0; i < this.Count; i++)
        {
            if (tempNode.Value.Equals(element))
            {
                return i;
            }

            tempNode = tempNode.NextNode;
        }

        return -1;
    }

    public int LastIndexOf(T element)
    {
        Node<T> tempNode = this.headNode;

        int tempIndex = 0;
        bool foundIndex = false;

        for (int i = 0; i < this.Count; i++)
        {
            if (tempNode.Value.Equals(element))
            {
                tempIndex = i;
                foundIndex = true;
            }

            tempNode = tempNode.NextNode;
        }

        if (foundIndex)
        {
            return tempIndex;
        }

        return -1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
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