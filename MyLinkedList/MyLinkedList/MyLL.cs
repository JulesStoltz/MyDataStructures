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

        /// <summary>Adds newData after the first occurence of data found.</summary>
        /// <param name="data">Type of 'data' must agree with list type.</param>
        /// <param name="newData">Type of 'data' must agree with list type.</param>
        public void AddAfter(T data, T newData) // Time: O(N), Space: O(1)
        {
            Node<T> target = new Node<T>(data);
            Node<T> current = this.Head;
            while (current.Next != null && !current.Equals(target))
            {
                current = current.Next;
            }
            if (!current.Equals(target)) { throw new ArgumentException("Item not found."); }
            if (current.Next == null) { AddAtEnd(newData); }
            else
            {
                Node<T> node = new Node<T>(newData);
                current.Next.Prev = node;
                node.Next = current.Next;
                node.Prev = current;
                current.Next = node;

                this.Size++;
            }
        }

        /// <summary>Adds newItem before the first occurence of anyItem.</summary>
        /// <param name="data">Type of 'data' must agree with list type.</param>
        /// <param name="newData">Type of 'data' must agree with list type.</param>
        public void AddBefore(T data, T newData) // Time: O(N), Space: O(1)
        {
            Node<T> target = new Node<T>(data);
            Node<T> current = this.Head;
            while (current.Next != null && !current.Equals(target))
            {
                current = current.Next;
            }
            if (!current.Equals(target)) { throw new ArgumentException("Item not found."); }
            if (current == this.Head) { AddAtFront(newData); }
            else
            {
                Node<T> node = new Node<T>(newData);
                current.Prev.Next = node;
                node.Next = current;
                current.Prev = node;
                this.Size++;
            }
        }

        /// <summary>Appends aList onto the end of this list.</summary>
        /// <param name="aList">Type of aList must agree with type of this list.</param>
        /// <returns>Returns a MyLL list (type T).</returns>
        public MyLL<T> Append(MyLL<T> aList) // Time: O(1), Space: O(1)
        {
            
            if ((this.Size == 0 && aList.Size == 0) || (aList.Size == 0)) { }
            else if (this.Size == 0)
            {
                this.Size = aList.Size;
                this.Head = aList.Head;
                this.Tail = aList.Tail;
            }
            else
            {
                this.Size = this.Size + aList.Size;
                this.Tail.Next = aList.Head;
                aList.Head.Prev = this.Tail;
                this.Tail = aList.Tail;
                this.Tail.Prev = aList.Tail.Prev;
                aList = null;
            }
            return this;
        }

        /// <summary>Deletes item found at index.</summary>
        /// <param name="index">Standard index values (first item is index 0).</param>
        public void DeleteIndex(int index) // Time: O(N), Space: O(1)
        {
            if (index < 0) { throw new IndexOutOfRangeException("Index cannot be negative."); }
            Node<T> current = this.Head;
            for (int i = 0; i < index; i++)
            {
                if (current.Next != null)
                {
                    current = current.Next;
                }
                else { throw new IndexOutOfRangeException(); }
            }
            current.Next.Prev = current.Prev;
            current.Prev.Next = current.Next;
            current = null;
            this.Size--;

        }
    }
}
