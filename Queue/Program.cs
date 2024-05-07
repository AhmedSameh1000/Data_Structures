using SingleList;

namespace Stack
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //var ququ = new Queue_based_Array(5);
            //try
            //{
            //    ququ.Enqueue(5);
            //    ququ.Enqueue(3);
            //    ququ.Enqueue(2);
            //    ququ.Enqueue(1);
            //    ququ.Enqueue(2);
            //    ququ.Dequeue();
            //    ququ.Enqueue(10);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //ququ.display();
        }
    }

    public class Queue_Based_LinkedList
    {
        private Linked_List _Linked_List;

        public Queue_Based_LinkedList()
        {
            _Linked_List = new Linked_List();
        }

        public void enque(int value)
        {
            this._Linked_List.Insert_End(value);
        }

        public int deque()
        {
            return this._Linked_List.Delete_Front();
        }

        public void Display()
        {
            this._Linked_List.print();
        }

        public bool isEmpty()
        {
            return _Linked_List.length == 0;
        }
    }
}