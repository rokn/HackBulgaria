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

            front = back = capacity / 2;
        }

        public Dequeue(params T[] data)
        {
            this.data = data;
            capacity = data.Length;
        }

        public void Clear()
        {
            front = back = capacity / 2
        }
    }
}
