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
    public class Node : IDisposable
    {
        public int _data { get; private set; }
        public Node next;

        public Node(int data)
        {
            _data = data;
        }

        public static void Print(Node head)
        {
            while (head != null)
            {
                Console.WriteLine(head._data);
                head = head.next;
            }
        }

        public static void PrintRecursive(Node head)
        {
            if (head is null)
                return;

            Console.WriteLine(head._data);
            PrintRecursive(head.next);
        }

        public static Node FindByValue(int value, Node head)
        {
            for (var node = head; node != null; node = node.next)
            {
                if (node._data == value)
                    return node;
            }

            return null!;
        }

        public void Dispose()
        {
            // Clean up resources here if needed
            next = null;
        }
    }
}