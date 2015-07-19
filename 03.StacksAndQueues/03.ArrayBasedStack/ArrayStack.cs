using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace ArrayStack
{
    public class ArrayStack<T>
    {
        private T[] stackElements;
        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.stackElements = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        private void Grow()
        {
            T[] newArray = new T[stackElements.Length * 2];

            for (int i = 0; i < stackElements.Length; i++)
            {
                newArray[i] = stackElements[i];
            }

            stackElements = newArray;
        }

        public void Push(T element)
        {
            if (this.Count == stackElements.Length)
            {
                Grow();
            }

            stackElements[this.Count] = element;

            this.Count++;
        }

        public T Pop()
        {
            this.Count--;
            return stackElements[this.Count];
        }

        public T[] ToArray()
        {
            var reversedArray = new T[this.Count];

            int count = 0;

            for (int i = this.Count - 1; i > -1; i--)
            {
                reversedArray[count] = stackElements[i];

                count++;
            }

            return reversedArray;
        }
    }
}