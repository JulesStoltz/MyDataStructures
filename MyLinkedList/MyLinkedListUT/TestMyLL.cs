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
            // CAUTION: Head and Tail of 1 node list should be the same node, not just equivalent value
            Assert.AreEqual(ll.GetHeadData(), ll.GetTailData());
        }

        [TestMethod]
        public void TestGetSizeMultipleNodeList()
        {
            // Doubles as test of Multiple Data Constructor
            int[] intArray = { 1,2,3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            var expect = (int)3;
            var actual = ll.GetSize();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetHeadDataNullValue()
        {
            MyLL<string> ll = new MyLL<string>();
            var errata = ll.GetHeadData();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetTailDataNullValue()
        {
            MyLL<string> ll = new MyLL<string>();
            var errata = ll.GetTailData();
        }

        [TestMethod]
        public void TestNodeDataLinkedListValue()
        {
            MyLL<int> llinner = new MyLL<int>(1);
            MyLL<MyLL<int>> llouter = new MyLL<MyLL<int>>(llinner);
            var actual = llouter.GetHeadData();
            Assert.IsInstanceOfType(actual, llinner.GetType());
        }

        [TestMethod]
        public void TestToStringOverride()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            var expect = "1, 2, 3";
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestToStringOverrideEmptyList()
        {
            MyLL<int> ll = new MyLL<int>();
            var expect = "";
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }
    }
}
