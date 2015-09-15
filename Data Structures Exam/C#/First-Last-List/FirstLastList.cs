using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{

    private List<T> elements = new List<T>();

    public void Add(T newElement)
    {
        elements.Add(newElement);
    }

    public int Count
    {
        get { return this.elements.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Skip(Math.Max(0, this.elements.Count() - count)).Reverse();
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.OrderBy(e => e).Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var productsFound = this.elements.OrderBy(e => e).Skip(this.elements.Count - count).Reverse();

        return productsFound;
    }

    public int RemoveAll(T element)
    {
        return this.elements.RemoveAll(e => element.CompareTo(e) == 0);
    }

    public void Clear()
    {
        this.elements.Clear();
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Wintellect.PowerCollections;

//public class FirstLastList<T> : IFirstLastList<T>
//    where T : IComparable<T>
//{
//    private OrderedBag<T> elements = new OrderedBag<T>();
//    private LinkedList<T> elementsInOrder = new LinkedList<T>();

//    public void Add(T newElement)
//    {
//        elements.Add(newElement);
//        elementsInOrder.AddLast(newElement);
//    }

//    public int Count
//    {
//        get { return this.elements.Count; }
//    }

//    public IEnumerable<T> First(int count)
//    {
//        if (count > this.elements.Count)
//        {
//            throw new ArgumentOutOfRangeException();
//        }

//        return this.elementsInOrder.Take(count);
//    }

//    public IEnumerable<T> Last(int count)
//    {
//        if (count > this.elements.Count)
//        {
//            throw new ArgumentOutOfRangeException();
//        }

//        return this.elements.Take(count);
//    }

//    public IEnumerable<T> Min(int count)
//    {
//        if (count > this.elements.Count)
//        {
//            throw new ArgumentOutOfRangeException();
//        }

//        return this.elements.Take(count);
//    }

//    public IEnumerable<T> Max(int count)
//    {
//        if (count > this.elements.Count)
//        {
//            throw new ArgumentOutOfRangeException();
//        }

//        var lastElement = this.elements.GetLast();

//        return this.elements.RangeFrom(lastElement, true);
//    }

//    public int RemoveAll(T element)
//    {
//        this.elementsInOrder.RemoveAll(e => e.Equals(element));
//        return this.elements.RemoveAllCopies(element);
//    }

//    public void Clear()
//    {
//        this.elements.Clear();
//        this.elementsInOrder.Clear();
//    }
//}
