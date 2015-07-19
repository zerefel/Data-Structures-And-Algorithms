using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08.LinkedQueueTests
{
    [TestClass]
    public class LinkedQueueToArray
    {
        [TestMethod]
        public void TestToArray_ShouldReturnElements()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(5);
            linkedQueue.Enqueue(-2);
            linkedQueue.Enqueue(7);

            var queueToArray = linkedQueue.ToArray();

            Assert.AreEqual(3, queueToArray[0]);
            Assert.AreEqual(5, queueToArray[1]);
            Assert.AreEqual(-2, queueToArray[2]);
            Assert.AreEqual(7, queueToArray[3]);

            Assert.AreEqual(4, linkedQueue.Count);
        }

        [TestMethod]
        public void TestEmptyQueueToArray_ShouldReturnEmptyArray()
        {
            var linkedQueue = new LinkedQueue<int>();
            var queueToArray = linkedQueue.ToArray();

            Assert.AreEqual(0, queueToArray.Length);
        }
    }
}
