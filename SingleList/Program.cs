namespace SingleList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var node1 = new Node(6);
            //var node2 = new Node(10);
            //var node3 = new Node(8);
            //var node4 = new Node(15);

            //node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = null!;

            //var node = Node.FindByValue(8, node1);

            //Console.WriteLine(node.next._data);
            //Console.WriteLine("---------");

            using (var list = new Linked_List())
            {
                list.Insert_End(7);
                list.Insert_End(10);
                list.Insert_End(1);
                list.Insert_End(9);
                list.Insert_End(9);
                list.Insert_End(9);

                list.Reverse();
                list.print();
                Console.WriteLine("-----");
            }
        }
    }
}