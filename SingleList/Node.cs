using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleList
{
    public class Node
    {
        public int _data { get; private set; }
        public Node next;

        public Node(int data)
        {
            _data = data;
        }
    }
}