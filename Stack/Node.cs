namespace Stack
{
    public class Node<T>
    {
        public T _data { get; private set; }

        public Node(T data)
        {
            _data = data;
        }

        public Node<T> Next { get; set; }
    }
}