using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SingleList
{
    public class Node
    {
        public int _data { get; private set; }
        public Node next;
        public Node prev;

        public int length { get; private set; }

        public Node(int data)
        {
            _data = data;
        }

        public void set(Node next, Node prev)
        {
            this.next = next;
            this.prev = prev;
        }
    }
}