using System;

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
        public MyLL(T[] data)
        {
            foreach(T item in data)
            {
                Node<T> node = new Node<T>(item);
                if (this.Size == 0) { this.Head = node; this.Tail = node; }
                else { this.Tail.Next = node; node.Prev = this.Tail; this.Tail = node; }
                this.Size++;
            }
        }

        // Methods

        /// <summary>Retrieves size (number of nodes) of linked list.</summary>
        /// <returns>Returns an int.</returns>
        public int GetSize() { return this.Size; }

        /// <summary>Retrieves data value of head node.</summary>
        /// <returns>Returns node type (T).</returns>
        public T GetHeadData() { return this.Head.Data; }

        /// <summary>Retrieves data value of tail node.</summary>
        /// <returns>Returns node type (T).</returns>
        public T GetTailData() { return this.Tail.Data; }
    }
}
