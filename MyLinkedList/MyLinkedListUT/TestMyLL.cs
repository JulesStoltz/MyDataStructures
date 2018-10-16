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

        [TestMethod]
        public void TestAddAtEndToEmptyList()
        {
            MyLL<int> ll = new MyLL<int>();
            var expect = "1";
            ll.AddAtEnd(1);
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestAddAtEndToNonEmptyList()
        {
            MyLL<int> ll = new MyLL<int>(1);
            var expect = "1, 2";
            ll.AddAtEnd(2);
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestAddAtFrontToEmptyList()
        {
            MyLL<int> ll = new MyLL<int>();
            var expect = "1";
            ll.AddAtFront(1);
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestAddAtFrontToNonEmptyList()
        {
            MyLL<int> ll = new MyLL<int>(1);
            var expect = "2, 1";
            ll.AddAtFront(2);
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestAddAfterDataPresent()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.AddAfter(2, 4);
            var expect = "1, 2, 4, 3";
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddAfterDataNotPresent()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.AddAfter(4, 2);
        }

        [TestMethod]
        public void TestAddBeforeDataPresent()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.AddBefore(2, 4);
            var expect = "1, 4, 2, 3";
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddBeforeDataNotPresent()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.AddBefore(4, 2);
        }

        [TestMethod]
        public void TestAppendEmptyToEmpty()
        {
            MyLL<int> lla = new MyLL<int>();
            MyLL<int> llb = new MyLL<int>();
            lla.Append(llb);
            var expect = 0;
            var actual = lla.GetSize();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestAppendEmptyToNonEmpty()
        {
            MyLL<int> lla = new MyLL<int>();
            MyLL<int> llb = new MyLL<int>(1);
            lla.Append(llb);
            var expect = "1";
            var actual = lla.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestAppendNonEmptyToEmpty()
        {
            MyLL<int> lla = new MyLL<int>(1);
            MyLL<int> llb = new MyLL<int>();
            lla.Append(llb);
            var expect = "1";
            var actual = lla.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestAppendNonEmptyToNonEmpty()
        {
            int[] intsA = { 1, 2 };
            int[] intsB = { 3, 4 };
            MyLL<int> lla = new MyLL<int>(intsA);
            MyLL<int> llb = new MyLL<int>(intsB);
            lla.Append(llb);
            var expect = "1, 2, 3, 4";
            var actual = lla.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestDeleteIndexPresent()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.DeleteIndex(1);
            var expect = "1, 3";
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestDeleteIndexOutOfRangeNegative()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.DeleteIndex(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestDeleteIndexOutOfRangePositive()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.DeleteIndex(3);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestPopFrontEmptyList()
        {
            MyLL<int> ll = new MyLL<int>();
            var errata = ll.PopFront();
        }

        [TestMethod]
        public void TestPopFrontNonEmptyList()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            var expect = 1;
            var actual = ll.PopFront();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestPopEndEmptyList()
        {
            MyLL<int> ll = new MyLL<int>();
            var errata = ll.PopEnd();
        }

        [TestMethod]
        public void TestPopEndNonEmptyList()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            var expect = 3;
            var actual = ll.PopEnd();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPopAfterDataNotPresent()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.PopAfter(4);
        }

        [TestMethod]
        public void TestPopAfterDataPresentItemAfterPresent()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.PopAfter(1);
            var expect = "1, 3";
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void TestPopAfterDataPresentItemAfterPresentLastItem()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.PopAfter(2);
            var expect = "1, 2";
            var actual = ll.ToString();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPopAfterDataPresentItemAfterNotPresent()
        {
            int[] intArray = { 1, 2, 3 };
            MyLL<int> ll = new MyLL<int>(intArray);
            ll.PopAfter(3);
        }
    }
}
