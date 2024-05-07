namespace Stack
{
    public class Stack_Based_Array
    {
        public int size { get; private set; } = 0;
        public int Top { get; private set; } = -1;

        public int[] arr { get; private set; }

        public Stack_Based_Array(int size)
        {
            this.size = size;
            arr = new int[size];
        }

        public bool is_Empty()
        {
            return Top == -1;
        }

        public bool is_Full()
        {
            return Top == size - 1;
        }

        public void Push(int value)
        {
            if (is_Full())
                throw new InvalidOperationException("Stack is Full");
            arr[++Top] = value;
        }

        public int pop()
        {
            if (is_Empty())
                throw new InvalidOperationException("Stack is Empty");
            return arr[Top--];
        }

        public int Peek()
        {
            if (is_Full())
                throw new InvalidOperationException("Stack is Empty");
            return arr[Top];
        }

        public void Print()
        {
            for (int i = Top; i >= 0; i--)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}