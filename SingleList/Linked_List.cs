using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SingleList
{
    public class Linked_List : IDisposable
    {
        public Node _Head { get; private set; }
        public Node _Tail { get; set; }
        public int length { get; private set; } = 0;

        public void print()
        {
            var temp = _Head;

            while (temp != null)
            {
                Console.WriteLine($"{temp._data}");
                temp = temp.next;
            }
        }

        public Node GetMiddle()
        {
            double len = length;
            var Node = GetValueByLengthNumber(Convert.ToInt32(Math.Ceiling(len / 2d)));

            return Node;
        }

        public void Insert_End(int value)
        {
            var Node = new Node(value);

            if (_Head is null)
            {
                _Head = _Tail = Node;
            }
            else
            {
                _Tail.next = Node;
                _Tail = Node;
            }

            length++;
        }

        public void Insert_Front(int value)
        {
            var node = new Node(value);
            node.next = _Head;
            _Head = node;
            length++;
        }

        public void Reverse()
        {
            if (_Head == null || _Head.next == null)
                return; // No need to reverse if the list is empty or has only one node

            Node prev = null;
            Node current = _Head;
            Node next = null;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            _Head = prev; //
        }

        public void Delete_Front()
        {
            if (_Head is null)
                throw new InvalidOperationException("Linked list is empty");

            _Head = _Head.next;
            length--;
        }

        public void Delete_Back()
        {
            if (_Head is null)
                throw new InvalidOperationException("Linked list is empty");

            if (_Head.next is null)
            {
                _Head = null!;
            }
            else
            {
                //for (var node = _Head; node != null; node = node.next)
                //{
                //    var PrevTail = node.next.next;
                //    if (PrevTail is null)
                //    {
                //        node.next = null;
                //        node = _Tail;
                //        return;
                //    }
                //}

                var node = GetValueByLengthNumber(length - 1);

                _Tail = node;
                _Tail.next = null;
            }
        }

        public Node GetValueByLengthNumber(int number)
        {
            var num = 1;
            for (var node = _Head; node != null; node = node.next)
            {
                if (num == number)
                    return node;

                num++;
            }

            return null;
        }

        public void DeleteNode(int number)
        {
            if (_Head is null || number < 1 || number > length)
                return;

            if (number == 1)
            {
                Delete_Front();
            }
            else if (number == length)
            {
                Delete_Back();
            }
            else
            {
                var Cur = GetValueByLengthNumber(number - 1);
                var prev = GetValueByLengthNumber(number - 1);
                var next = GetValueByLengthNumber(number + 1);

                prev.next = next;
                Cur = null;
            }
        }

        public int IndexOfValue(int value)
        {
            var index = 0;
            for (var node = _Head; node != null; node = node.next)
            {
                if (node._data == value)
                    return index;

                index++;
            }

            return -1;
        }

        public void Dispose()
        {
            var current = _Head;
            while (current != null)
            {
                var next = current.next;
                current.Dispose();
                current = next;
            }
            _Head = _Tail = null;
        }
    }
}