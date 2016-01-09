using System;

namespace LinkedList
{
    public class LinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }
        
        private Node Head { get; set; }

        private int count;

        public LinkedList()
        {
            Count = 0;
        }

        public int Count
        {
            get { return count; }

            private set
            {
                count = value;

                if(count < 0)
                {
                    count = 0;
                }
            }
        }

        public void Add(T value)
        {
            if(Head == null)
            {
                Head = new Node(value, null);
            }
            else
            {
                Node temp = Head;

                while(temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = new Node(value, null);
            }

            Count++;
        }

        public void InsertAfter(T key, T value)
        {
            Node temp = Head;

            while (!temp.Value.Equals(key) && temp != null)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                throw new ArgumentException("No such key found");
            }

            temp.Next = new Node(value, temp.Next);

            Count++;
        }

        public void InsertBefore(T key, T value)
        {
            Node temp = Head;

            while (!temp.Next.Value.Equals(key) && temp != null)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                throw new ArgumentException("No such key found");
            }

            temp.Next = new Node(value, temp.Next);
            Count++;
        }

        public void InsertAt(int index, T value)
        {
            Node temp;
            temp = GetAtIndex(index-1);
            temp.Next = new Node(value, temp.Next);
            Count++;
        }

        public void Remove(T value)
        {
            if(Count <= 0)
            {
                throw new IndexOutOfRangeException("There are no elements in the list");
            }

            Node temp = Head;

            while (!temp.Next.Value.Equals(value) && temp != null)
            {
                temp = temp.Next;
            }

            temp.Next = temp.Next.Next;

            Count--;
        }

        public void RemoveAt(int index)
        {
            Node temp;
            temp = GetAtIndex(index - 1);
            temp.Next = temp.Next.Next;
            Count--;
        }

        public void Clear()
        {
            Node temp = Head;
            Node temp2;

            while(temp != null)
            {
                temp2 = temp.Next;
                temp.Next = null;
                temp = temp2;
            }

            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                return GetAtIndex(index).Value;
            }

            set
            {
                GetAtIndex(index).Value = value;
            }
        }

        private Node GetAtIndex(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index can't be larger than size");
            }

            Node temp = Head;

            for (int i = 1; i <= index; i++)
            {
                temp = temp.Next;
            }

            return temp;
        }
    }
}
