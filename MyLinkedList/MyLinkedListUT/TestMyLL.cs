using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinkedList;

namespace MyLinkedListUT
{
    [TestClass]
    public class TestMyLL
    {
        [TestMethod]
        public void TestGetSizeEmptyList()
        {
            // Doubles as test of Empty Constructor
            MyLL<int> ll = new MyLL<int>();
            var expect = (int)0;
            var actual = ll.GetSize();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestGetSizeOneNodeList()
        {
            // Doubles as test of Single Data Constructor
            MyLL<int> ll = new MyLL<int>(3);
            var expect = (int)1;
            var actual = ll.GetSize();
            Assert.AreEqual(expect, actual);
        }
    }
}
