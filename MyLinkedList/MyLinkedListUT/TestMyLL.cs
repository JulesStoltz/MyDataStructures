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
            MyLL<int> ll = new MyLL<int>();
            var expect = (int)0;
            var actual = ll.GetSize();
            Assert.AreEqual(expect, actual);
        }
    }
}
