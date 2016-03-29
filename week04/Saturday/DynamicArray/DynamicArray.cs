using System;

namespace DynamicArray
{
    public class DynamicArray<T>
    {
		private T[] _data;
	    int _size;

		public DynamicArray()
            :this(10)
        { }

		public DynamicArray(int capacity)
		{
			_data = new T[capacity];
			_size = 0;
			this.Capacity = capacity;
		}

		public int Count => _size;

	    public int Capacity { get; private set; }

	    public void InsertAt(int index, T value)
	    {
			if(_size >= Capacity - 1)
			{
				Resize();
			}

		    _size++;

		    for (int i = _size; i > index; i++)
		    {
			    _data[i] = _data[i - 1];
		    }

		    _data[index] = value;
	    }

		public void Add(T element)
		{
			if(_size >= Capacity - 1)
			{
				Resize();
			}

			_data[_size++] = element;
		}

	    public void Remove(T value)
	    {
		    for (int i = 0; i < _size; i++)
		    {
			    if (_data[i].Equals(value))
			    {
				    RemoveAt(i);
				    break;
			    }
		    }
	    }


		public void RemoveAt(int index)
	    {
		    if (_size <= Capacity/3)
		    {
			    Resize(false);
		    }

			_size--;

			for(int i = index; i < _size; i++)
			{
				_data[i] = _data[i + 1];
			}
		}

		private void Resize(bool up = true)
		{
			if (up)
			{
				if (Capacity <= 2048)
				{
					Capacity *= 2;
				}
				else
				{
					Capacity = 256;
				}
			}
			else
			{
				Capacity /= 2;
			}

			var newData = new T[Capacity];
			_data.CopyTo(newData, 0);
			_data = newData;
		}

		public void Clear()
		{
			_size = 0;
			_data = new T[10];
		}

		public bool Contains(T value)
		{
			for(var i = 0; i <= _size; i++)
			{
				if(_data[i].Equals(value))
				{
					return true;
				}
			}

			return false;
		}

	    public int IndexOf(T value)
	    {
			for(var i = 0; i <= _size; i++)
			{
				if(_data[i].Equals(value))
				{
					return i;
				}
			}

		    return -1;
	    }

	    public T[] ToArray()
	    {
			T[] copy = new T[_size];
			_data.CopyTo(copy, 0);
		    return copy;
	    }

	    public T this[int i]
	    {
		    get { return _data[i]; }
		    set { _data[i] = value; }
	    }
	}
}
