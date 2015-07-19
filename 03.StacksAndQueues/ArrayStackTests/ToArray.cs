namespace ArrayStackTests
{
    using System;
    using ArrayStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToArray
    {
        [TestMethod]
        public void TestToArray_ShouldReturnElementsInReverseOrder()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(3);
            arrayStack.Push(5);
            arrayStack.Push(-2);
            arrayStack.Push(7);

            var stackToArray = arrayStack.ToArray();

            Assert.AreEqual(7, stackToArray[0]);
            Assert.AreEqual(-2, stackToArray[1]);
            Assert.AreEqual(5, stackToArray[2]);
            Assert.AreEqual(3, stackToArray[3]);
        }

        [TestMethod]
        public void TestToEmptyStackToArray_ShouldReturnEmptyArray()
        {
            var arrayStack = new ArrayStack<DateTime>();

            // I don'get the problem. Should pushing dates not work? Why do we expect an empty array when pusing ordinary dates?

            //arrayStack.Push(DateTime.Now);
            //arrayStack.Push(DateTime.Now);
            //arrayStack.Push(DateTime.Now);
            //arrayStack.Push(DateTime.Now);

            var stackToArray = arrayStack.ToArray();

            Assert.AreEqual(0, stackToArray.Length);
        }
    }
}