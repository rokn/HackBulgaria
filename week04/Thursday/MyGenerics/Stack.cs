using System;

namespace MyGenerics
{
    public class Stack<T>
    {
        private T[] data;
        private int capacity;
        int top;

        public Stack()
            :this(8)
        { }

        public Stack(int capacity)
        {
            data = new T[capacity];
            top = -1;
            this.capacity = capacity;
        }

        public Stack(params T[] data)
        {
            this.data = data;
            top = data.Length - 1;
            capacity = top;
        }

        public int Count
        {
            get { return top + 1; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public T Peek()
        {
            if (top < 0)
                throw new IndexOutOfRangeException("There are no elements in the stack");

            return data[top];
        }

        public T Pop()
        {
            if (top < 0)
                throw new IndexOutOfRangeException("There are no elements in the stack");

            return data[top--];
        }

        public void Push(T element)
        {
            if(top >= capacity - 1)
            {
                Resize();
            }

            data[++top] = element;
        }

        private void Resize()
        {
            T[] newData = new T[capacity *= 2];
            data.CopyTo(newData, 0);
            data = newData;
        }

        public void Clear()
        {
            top = -1;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i <= top; i++)
            {
                if(data[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
