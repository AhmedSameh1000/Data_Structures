namespace Stack
{
    public class Queue_based_Array
    {
        public int size { get; private set; }
        public int front { get; private set; } = 0;
        public int rear { get; private set; } = 0;

        public int added_Elements { get; private set; } = 0;
        public int[] arr { get; private set; }

        public Queue_based_Array(int size)
        {
            this.size = size;
            arr = new int[size];
        }

        public void Enqueue(int value)
        {
            if (isFull())
                throw new InvalidOperationException("Queue Full");

            arr[rear] = value;
            rear = next(rear);
            added_Elements++;
        }

        public int Dequeue()
        {
            if (isEmpty())
                throw new InvalidOperationException("Queue Full");

            var value = arr[front];

            front = next(front);
            added_Elements--;

            return value;
        }

        public int next(int pos)
        {
            ++pos;
            if (pos == size)
                pos = 0;

            return pos;
        }

        public bool isEmpty() => added_Elements == 0;

        public bool isFull() => added_Elements == size;

        public void display()
        {
            //for (int cur = front, step = 0; step < added_Elements; ++step, cur = next(cur))
            //{
            //    Console.WriteLine(arr[cur]);
            //}

            for (int i = 0; i < added_Elements; i++)
            {
                int index = (front + i) % size;
                Console.WriteLine(arr[index]);
            }
        }
    }
}