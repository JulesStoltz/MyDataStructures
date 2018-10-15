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
        public MyLL(T data) { this.Head = new Node<T>(data); this.Size++; }
        public MyLL(T[] data) { }

        // Methods

        /// <summary>Retrieves size (number of nodes) of linked list.</summary>
        /// <returns>Returns an int.</returns>
        public int GetSize() { return this.Size; }
    }
}
