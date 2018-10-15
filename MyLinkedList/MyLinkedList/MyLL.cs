using System;
using System.Text;

namespace MyLinkedList
{
    public class MyLL<T>
    {
        // Properties
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        private int Size { get; set; }

        // Inner Record Class
        private class Node<T>
        {
            public Node<T> Next { get; set; }
            public Node<T> Prev { get; set; }
            public T Data { get; set; }

            public Node(T data) { Data = data; }

            public bool Equals(Node<T> obj)
            {
                return Data.Equals(obj.Data);
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        // Constructors
        public MyLL() { }
        public MyLL(T data) : this(new T[] { data }) { }
        public MyLL(T[] data) { foreach(T item in data) { AddAtEnd(item); } }

        // Methods

        /// <summary>Retrieves size (number of nodes) of linked list.</summary>
        /// <returns>Returns an int.</returns>
        public int GetSize() { return this.Size; }

        /// <summary>Retrieves data value of head node.</summary>
        /// <returns>Returns node type (T).</returns>
        public T GetHeadData()
        {
            if (this.Size > 0) { return this.Head.Data; }
            else { throw new NullReferenceException(); }
        }

        /// <summary>Retrieves data value of tail node.</summary>
        /// <returns>Returns node type (T).</returns>
        public T GetTailData()
        {
            if (this.Size > 0) { return this.Tail.Data; }
            else { throw new NullReferenceException(); }
        }

        /// <summary>Creates list as a string.</summary>
        /// <returns>Returns string.</returns>
        public override string ToString() // Time: O(N), Space: O(N)
        {
            Node<T> current = this.Head;
            StringBuilder sb = new StringBuilder();
            int count = 0;
            while (current != null)
            {
                if (current.Next != null)
                {
                    sb.Append(current.Data.ToString() + ", ");
                    current = current.Next;
                }
                else
                {
                    sb.Append(current.Data.ToString());
                    break;
                }
                count++;
            }
            return sb.ToString();
        }

        /// <summary>Adds data item to the end of the list.</summary>
        /// <param name="data">Type of 'data' must agree with list type.</param>
        public void AddAtEnd(T data) // Time: O(1), Space: O(1)
        {
            Node<T> node = new Node<T>(data);
            if (this.Size == 0) { this.Head = node; this.Tail = node; }
            else { this.Tail.Next = node; node.Prev = this.Tail; this.Tail = node; }
            this.Size++;
        }

        /// <summary>Adds data item to the front of the list.</summary>
        /// <param name="data">Type of 'data' must agree with list type.</param>
        public void AddAtFront(T data) // Time: O(1), Space: O(1)
        {
            Node<T> node = new Node<T>(data);
            if (this.Size == 0) { this.Head = node; this.Tail = node; }
            else { this.Head.Prev = node; node.Next = this.Head; this.Head = node; }
            this.Size++;
        }
    }
}
