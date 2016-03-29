using System;
using System.Data;

namespace Stack
{
    public class Dequeue<T>
    {
        T[] data;
        int front, back;
        int capacity;
        int size;

        public Dequeue(int capacity)
        {
            data = new T[capacity];
            this.capacity = capacity;
	        size = 0;

            front = back = capacity / 2;
        }

        public Dequeue(params T[] data)
        {
            this.data = data;
            capacity = data.Length;
	        size = capacity;
	        front = 0;
	        back = data.Length - 1;
        }

        public void Clear()
        {
            front = back = capacity / 2;
        }

		public bool Contains(T item)
	    {
			for (var i = front; i < back; i++)
			{
				if (item.Equals(data[i]))
				{
					return true;
				}
			}

			return false;
	    }

	    public T RemoveFromFront()
	    {
		    if (size <= 0)
		    {
			    throw new InvalidOperationException("Dequeue empty");
		    }

		    front ++;
		    size --;
		    return data[front - 1];
	    }

	    public T RemoveFromEnd()
	    {
			if(size <= 0)
			{
				throw new InvalidOperationException("Dequeue empty");
			}

			back--;
			size--;
			return data[back + 1];
		}

	    public void AddToFront(T item)
	    {
		    if (front == 0)
		    {
			    Resize();
		    }

		    data[--front] = item;
		    size ++;
	    }

	    public void AddToEnd(T item)
	    {
		    if (back == capacity - 1)
		    {
			    Resize();
		    }

		    data[++back] = item;
		    size++;
	    }

	    public T PeekFromFront()
	    {
		    return data[front];
	    }

	    public T PeekFromEnd()
	    {
		    return data[back];
	    }

	    private void Resize()
	    {
		    var oldData = data;

		    capacity *= 2;
			data = new T[capacity];
		    int startIndex = capacity/2 - size/2;

		    for (int i = 0; i < size; i++)
		    {
			    data[startIndex + i] = oldData[front + i];
		    }
	    }
	}
}
