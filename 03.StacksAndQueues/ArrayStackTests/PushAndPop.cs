namespace ArrayStackTests
{
    using System;
    using ArrayStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PushAndPop
    {
        [TestMethod]
        public void CheckInitialCount_ShouldBeZero()
        {
            var arrayStack = new ArrayStack<int>();
            Assert.AreEqual(0, arrayStack.Count);
        }

        [TestMethod]
        public void CheckCountAfterOnePush_ShouldBeOne()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(1);

            Assert.AreEqual(1, arrayStack.Count);
        }

        [TestMethod]
        public void CheckCountAfterOnePop_ShouldBeZero()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(1);
            arrayStack.Pop();

            Assert.AreEqual(0, arrayStack.Count);
        }

        [TestMethod]
        public void CheckCountAfterEveryPush_ShouldIncreaseByOne()
        {
            var arrayStack = new ArrayStack<string>();

            for (int i = 0; i < 1000; i++)
            {
                arrayStack.Push("Element: " + i);
                Assert.AreEqual(i + 1, arrayStack.Count);
            }

        }

        [TestMethod]
        public void CheckCountAfterEveryPop_ShouldDecreaseByOne()
        {
            var arrayStack = new ArrayStack<string>();

            for (int i = 0; i < 1000; i++)
            {
                arrayStack.Push("Element: " + i);
            }

            for (int i = 1000; i > 0; i--)
            {
                arrayStack.Pop();
                Assert.AreEqual(i - 1, arrayStack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckCountOnEmptyPop_ShouldThrowException()
        {
            var arrayStack = new ArrayStack<int>();

            arrayStack.Pop(); 
        }


        [TestMethod]
        public void CheckInitialCapacity_ShouldReturnCorrectElement()
        {
            var arrayStack = new ArrayStack<int>(1);

            arrayStack.Push(1);
            Assert.AreEqual(1, arrayStack.Count);

            arrayStack.Push(100);
            Assert.AreEqual(2, arrayStack.Count);

            arrayStack.Pop();
            Assert.AreEqual(1, arrayStack.Count);

            int element = arrayStack.Pop();
            Assert.AreEqual(1, element);
            Assert.AreEqual(0, arrayStack.Count);
        }


    }
}
