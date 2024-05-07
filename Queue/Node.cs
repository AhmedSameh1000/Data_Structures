namespace Stack
{
    public class Node
    {
        public int _data { get; private set; }

        public Node(int data)
        {
            _data = data;
        }

        public Node Next { get; set; }
    }
}