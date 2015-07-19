using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08.LinkedQueueTests
{
    [TestClass]
    public class LinkedQueueEnqueueDequeue
    {
        [TestMethod]
        public void CheckInitialCount_ShouldBeZero()
        {
            var linkedQueue = new LinkedQueue<int>();
            Assert.AreEqual(0, linkedQueue.Count);
        }

        [TestMethod]
        public void CheckCountAfterOneEnqueue_ShouldBeOne()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(1);

            Assert.AreEqual(1, linkedQueue.Count);
        }

        [TestMethod]
        public void CheckCountAfterOneDequeue_ShouldBeZero()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(1);
            linkedQueue.Dequeue();

            Assert.AreEqual(0, linkedQueue.Count);
        }

        [TestMethod]
        public void CheckElementAfterOneDequeue_ShouldBeQueuedElement()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(1);
            int element = linkedQueue.Dequeue();

            Assert.AreEqual(1, element);
        }

        [TestMethod]
        public void CheckCountAfterEveryEnqueue_ShouldIncreaseByOne()
        {
            var linkedQueue = new LinkedQueue<string>();

            for (int i = 0; i < 1000; i++)
            {
                linkedQueue.Enqueue("Element: " + i);
                Assert.AreEqual(i + 1, linkedQueue.Count);
            }

        }

        [TestMethod]
        public void CheckCountAfterEveryDequeue_ShouldDecreaseByOne()
        {
            var linkedQueue = new LinkedQueue<string>();

            for (int i = 0; i < 1000; i++)
            {
                linkedQueue.Enqueue("Element: " + i);
            }

            for (int i = 1000; i > 0; i--)
            {
                linkedQueue.Dequeue();
                Assert.AreEqual(i - 1, linkedQueue.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CheckCountOnEmptyDequeue_ShouldThrowException()
        {
            var linkedQueue = new LinkedQueue<int>();

            linkedQueue.Dequeue();
        }


        [TestMethod]
        public void CheckInitialCapacity_ShouldReturnCorrectElement()
        {
            var linkedQueue = new LinkedQueue<int>();

            linkedQueue.Enqueue(1);
            Assert.AreEqual(1, linkedQueue.Count);

            linkedQueue.Enqueue(100);
            Assert.AreEqual(2, linkedQueue.Count);

            linkedQueue.Dequeue();
            Assert.AreEqual(1, linkedQueue.Count);

            int element = linkedQueue.Dequeue();
            Assert.AreEqual(100, element);
            Assert.AreEqual(0, linkedQueue.Count);
        }
    }
}
