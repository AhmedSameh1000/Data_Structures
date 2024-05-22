using System.ComponentModel.DataAnnotations;

namespace HashTable
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var arr = new List<int>() { 3, 7, 11, 15, 17, 28, 31 };

            Console.WriteLine(Sum(arr.ToArray(), 32));
        }

        public static int Sum(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left < right)
            {
                var sum = numbers[left] + numbers[right];

                if (sum == target)
                {
                    return (left + 1) + right + 1;
                }
                if (sum > target)
                    right++;
                else
                {
                    left++;
                }
            }
            return 0;
        }
    }

    public class Hash_Table
    {
        public Hash_Table()
        {
            for (int i = 0; i < TableSize; i++)
            {
                Backets[i] = new Node();
                Backets[i].data = null;
                Backets[i] = new Node();
                Backets[i].next = null;
            }
        }

        public Node[] Backets = new Node[TableSize];

        private static int TableSize = 10;

        public int Hash(string key)
        {
            var hash = 0;
            for (var i = 0; i < key.Length; i++)
            {
                hash += (int)key[i];
            }
            var index = hash % TableSize;
            return index;
        }

        public int NumberOfItemsInIndex(int index)
        {
            var Sum = 0;

            if (Backets[index].data is null)
            {
                return Sum;
            }
            else
            {
                var ptr = Backets[index];

                while (ptr != null)
                {
                    Sum++;
                    ptr = ptr.next;
                }
            }

            return Sum;
        }

        public void Add(string name)
        {
            var index = Hash(name);
            if (Backets[index].data is null)
            {
                Backets[index].data = name;
            }
            else
            {
                var Backet = Backets[index];
                var node = new Node();
                node.data = name;
                node.next = null;

                while (Backet.next != null)
                {
                    Backet = Backet.next;
                }
                Backet.next = node;
            }
        }
    }

    public class Node
    {
        public string data { get; set; }
        public Node next { get; set; }
    }
}