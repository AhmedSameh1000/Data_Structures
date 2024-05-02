namespace SingleList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var node1 = new Node(6);
            var node2 = new Node(10);
            var node3 = new Node(8);
            var node4 = new Node(15);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = null!;

            for (var node = node1; node != null; node = node.next)
            {
                Console.WriteLine(node._data);
            }
        }
    }
}