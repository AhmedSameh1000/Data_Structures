using System.Diagnostics;

namespace Bainary_tree
{
    [DebuggerDisplay("data = {data}")]
    public class Node
    {
        public int data { get; set; }

        public Node(int data)
        {
            this.data = data;
        }

        public Node left { get; set; }
        public Node right { get; set; }
    }
}