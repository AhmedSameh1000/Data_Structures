namespace Bainary_tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var Bs = new BinarySearchTree();
            var arr = new List<int>();

            arr.AddRange(new[] { 50, 9, 3, 2, 5, 8, 6, 1, 7, 100 });

            arr.ForEach(x => Bs.Add(x));

            Bs.RemoveNode(100);
            var find = Bs.FindByValue(50);
            Bs.PrintInOrder();
        }
    }
}

/*
  var root = new Node(50);
            var node21 = new Node(21);
            var node4 = new Node(4);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node14 = new Node(14);
            var node15 = new Node(15);
            var node32 = new Node(32);
            var node76 = new Node(76);
            var node100 = new Node(100);
            var node64 = new Node(64);
            var node52 = new Node(52);
            var node83 = new Node(83);
            var node80 = new Node(80);
            var node87 = new Node(87);
            var node70 = new Node(70);

            root.left = node21;
            node21.left = node4;
            node21.right = node32;
            node4.left = node2;
            node4.right = node15;
            node2.right = node3;
            node15.left = node14;

            root.right = node76;
            node76.right = node100;

            node100.left = node83;
            node83.left = node80;
            node83.right = node87;

            node76.left = node64;
            node64.left = node52;
            node64.right = node70;

            Print(root);
 */