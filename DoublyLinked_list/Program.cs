using SingleList;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

namespace DoublyLinked_list
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list1 = new Doubly_linkedList();
            var list2 = new Doubly_linkedList();

            list1.Insert_Sorted(10);

            list2.Insert_Sorted(7);

            var res = Merge(list1, list2);

            res.Print();
        }

        public static Doubly_linkedList Merge(Doubly_linkedList list1, Doubly_linkedList list2)
        {
            var head1 = list1.head;
            var head2 = list2.head;

            var list = new Doubly_linkedList();
            var length = list1.length + list2.length;
            while (length-- != 0)
            {
                if (head1 is not null)
                {
                    list.Insert_Sorted(head1._data);
                    head1 = head1.next;
                }

                if (head2 is not null)
                {
                    list.Insert_Sorted(head2._data);
                    head2 = head2.next;
                }
            }

            return list;
        }
    }

    public class Doubly_linkedList
    {
        public Node head { get; private set; }
        public Node tail { get; private set; }
        public int length { get; private set; } = 0;

        public void Insert_Sorted(int value)
        {
            if (head is null)
            {
                var node = new Node(value);
                head = tail = node;
                length++;
            }
            else
            {
                if (value <= head._data)
                    insertFront(value);
                else if (value >= tail._data)
                    Insert_end(value);
                else
                {
                    for (var Cur = head; Cur != null; Cur = Cur.next)
                    {
                        if (value <= Cur._data)
                        {
                            var mid = new Node(value);

                            var prev = Cur.prev;
                            prev.next = mid;

                            mid.prev = prev;
                            mid.next = Cur;
                            Cur.prev = mid;
                            return;
                        }
                    }
                    length++;
                }
            }
        }

        public void Reverse()
        {
            var cur = head;
            Node temp = null;

            while (cur is not null)
            {
                temp = cur.prev;
                cur.prev = cur.next;
                cur.next = temp;
                cur = cur.prev;
            }
            if (temp != null)
                head = temp.prev;
        }

        public int FindMiddle()
        {
            var num = 1;
            var mid = Math.Ceiling(length / 2d);

            for (var node = head; node != null; node = node.next)
            {
                if (mid == num)
                {
                    return node._data;
                }
                num++;
            }

            return -1;
        }

        public void Delete_front()
        {
            if (head is null)
                return;

            if (head.next is null)
                head = null;
            else
            {
                head = head.next;
                head.prev = null;
            }

            length--;
        }

        public void Delete_Even_Pos()
        {
            if (head is null)
                return;

            var num = 1;

            for (var node = head; node != null; node = node.next)
            {
                if (num % 2 == 0)
                {
                    if (node.next is null)
                    {
                        Delete_Back();
                    }
                    else
                    {
                        var prev = node.prev;
                        var next = node.next;

                        prev.next = next;
                        next.prev = prev;
                    }
                    length--;
                }

                num++;
            }
        }

        public void Delete_Odd_Pos()
        {
            if (head is null)
                return;

            var num = 1;

            for (var node = head; node != null; node = node.next)
            {
                if (num % 2 != 0)
                {
                    if (node.prev is null)
                    {
                        Delete_front();
                    }
                    else if (node.next is null)
                    {
                        Delete_Back();
                    }
                    else
                    {
                        var prev = node.prev;
                        var next = node.next;

                        prev.next = next;
                        next.prev = prev;
                    }
                    length--;
                }

                num++;
            }
        }

        public void Delete_Back()
        {
            if (head is null)
                return;

            if (head.next is null)
                head = null;
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
            length--;
        }

        private void Link(Node first, Node second)
        {
            if (first is null || second is null)
                throw new ArgumentNullException("must not be null");

            first.next = second;
            second.prev = first;
        }

        public void Delete_With_Key(int value)
        {
            var node = head;

            while (node != null)
            {
                if (head._data == value)
                {
                    Delete_front();
                }
                else if (tail._data == value)
                {
                    Delete_Back();
                }
                else
                {
                    for (var Cur = head; Cur != null; Cur = Cur.next)
                    {
                        if (Cur._data == value)
                        {
                            var prev = Cur.prev;

                            var next = Cur.next;
                            prev.next = next;

                            next.prev = prev;
                        }
                    }
                }
                node = node.next;
                length--;
            }
        }

        public void Delete_With_Key_v2(int value)
        {
            if (head is null)
                return;

            for (var Cur = head; Cur != null; Cur = Cur.next)
            {
                if (Cur._data == value)
                {
                    if (head._data == value)
                    {
                        Delete_front();
                    }
                    else if (tail._data == value)
                    {
                        Delete_Back();
                    }
                    else
                    {
                        Cur.prev.next = Cur.next;
                        Cur.next.prev = Cur.prev;
                    }

                    length--;
                }
            }
        }

        public void insertFront(int value)
        {
            var node = new Node(value);

            Link(node, head);
            head = node;
            length++;
        }

        public bool isPalindrome()
        {
            var start = head;
            var end = tail;

            while (start is not null && end is not null)
            {
                if (start._data != end._data)
                    return false;

                start = start.next;
                end = end.prev;
            }
            return true;
        }

        public void Insert_end(int value)
        {
            var node = new Node(value);
            if (head is null)
            {
                head = tail = node;
            }
            else
            {
                Link(tail, node);
                tail = node;
            }
            length++;
        }

        public void Print()
        {
            for (var node = head; node != null; node = node.next)
            {
                Console.WriteLine(node._data);
            }
        }

        public void Print_Reverse()
        {
            for (var node = tail; node != null; node = node.prev)
            {
                Console.WriteLine(node._data);
            }
        }
    }
}