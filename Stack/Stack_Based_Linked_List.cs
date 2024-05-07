namespace Stack
{
    public class Stack_Based_Linked_List<T>
    {
        public Node<T> head { get; private set; }

        public void Add_Element(T value)
        {
            var Node = new Node<T>(value);

            Node.Next = head;
            head = Node;
        }

        public Node<T> Pop()
        {
            if (head is null)
                throw new InvalidOperationException("Stack is empty");

            var Node = head;

            head = head.Next;

            return Node;
        }

        public Node<T> Peek()
        {
            if (head is null)
                throw new InvalidOperationException("Stack is empty");

            var Node = head;

            return Node;
        }

        public void Print()
        {
            for (var node = head; node != null; node = node.Next)
            {
                Console.WriteLine($"{node._data}");
            }
        }
    }
}