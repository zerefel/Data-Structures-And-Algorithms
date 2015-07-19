using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06.LinkedStackTests
{
    [TestClass]
    public class LinkedStackPushPop
    {
        [TestMethod]
        public void CheckInitialCount_ShouldBeZero()
        {
            var linkedStack = new LinkedStack<int>();
            Assert.AreEqual(0, linkedStack.Count);
        }

        [TestMethod]
        public void CheckCountAfterOnePush_ShouldBeOne()
        {
            var linkedStack = new LinkedStack<int>();
            linkedStack.Push(1);

            Assert.AreEqual(1, linkedStack.Count);
        }

        [TestMethod]
        public void CheckCountAfterOnePop_ShouldBeZero()
        {
            var linkedStack = new LinkedStack<int>();
            linkedStack.Push(1);
            linkedStack.Pop();

            Assert.AreEqual(0, linkedStack.Count);
        }

        [TestMethod]
        public void CheckCountAfterEveryPush_ShouldIncreaseByOne()
        {
            var linkedStack = new LinkedStack<string>();

            for (int i = 0; i < 1000; i++)
            {
                linkedStack.Push("Element: " + i);
                Assert.AreEqual(i + 1, linkedStack.Count);
            }

        }

        [TestMethod]
        public void CheckCountAfterEveryPop_ShouldDecreaseByOne()
        {
            var linkedStack = new LinkedStack<string>();

            for (int i = 0; i < 1000; i++)
            {
                linkedStack.Push("Element: " + i);
            }

            for (int i = 1000; i > 0; i--)
            {
                linkedStack.Pop();
                Assert.AreEqual(i - 1, linkedStack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CheckCountOnEmptyPop_ShouldThrowException()
        {
            var linkedStack = new LinkedStack<int>();

            linkedStack.Pop();
        }


        [TestMethod]
        public void CheckInitialCapacity_ShouldReturnCorrectElement()
        {
            var linkedStack = new LinkedStack<int>();

            linkedStack.Push(1);
            Assert.AreEqual(1, linkedStack.Count);

            linkedStack.Push(100);
            Assert.AreEqual(2, linkedStack.Count);

            linkedStack.Pop();
            Assert.AreEqual(1, linkedStack.Count);

            int element = linkedStack.Pop();
            Assert.AreEqual(1, element);
            Assert.AreEqual(0, linkedStack.Count);
        }

    }
}