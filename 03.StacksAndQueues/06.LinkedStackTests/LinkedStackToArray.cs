using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06.LinkedStackTests
{
    [TestClass]
    public class ToArray
    {
        [TestMethod]
        public void TestToArray_ShouldReturnElementsInReverseOrder()
        {
            var linkedStack = new LinkedStack<int>();
            linkedStack.Push(3);
            linkedStack.Push(5);
            linkedStack.Push(-2);
            linkedStack.Push(7);

            var stackToArray = linkedStack.ToArray();

            Assert.AreEqual(7, stackToArray[0]);
            Assert.AreEqual(-2, stackToArray[1]);
            Assert.AreEqual(5, stackToArray[2]);
            Assert.AreEqual(3, stackToArray[3]);
        }

        [TestMethod]
        public void TestToEmptyStackToArray_ShouldReturnEmptyArray()
        {
            var linkedStack = new LinkedStack<DateTime>();

            // I don'get the problem. Should pushing dates not work? Why do we expect an empty array when pusing ordinary dates?

            //linkedStack.Push(DateTime.Now);
            //linkedStack.Push(DateTime.Now);
            //linkedStack.Push(DateTime.Now);
            //linkedStack.Push(DateTime.Now);

            var stackToArray = linkedStack.ToArray();

            Assert.AreEqual(0, stackToArray.Length);
        }
    }
}
