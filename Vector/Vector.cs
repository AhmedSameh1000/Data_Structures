using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class Vector
    {
        private int[] arr;
        public int _size { get; private set; }
        public int capacity { get; private set; }

        public Vector(int size)
        {
            if (size < 0)
            {
                _size = 1;
            }
            _size = size;

            capacity = size + 4;
            arr = new int[capacity];
        }

        public void Add(int index, int value)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            arr[index] = value;
        }

        public void InsertAt(int index, int value)
        {
            if (_size == capacity)
                ExpandCapacity();

            for (int i = _size - 1; i >= index; i--)
                arr[i + 1] = arr[i];

            arr[index] = value;
            ++_size;
        }

        public void Append(int value)
        {
            if (_size == capacity)
                ExpandCapacity();

            arr[_size++] = value;
        }

        private void ExpandCapacity()
        {
            capacity *= 2;
            var newarr = new int[capacity];
            for (int i = 0; i < arr.Length; i++)
            {
                newarr[i] = arr[i];
            }
            arr = newarr;
        }

        public int GetFront()
        {
            return arr[0];
        }

        public int GetBack()
        {
            return arr[_size - 1];
        }

        public int Get(int index)
        {
            if (index <= 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }
            return arr[index];
        }

        public void Print()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public int findIndex(int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (value == arr[i])
                    return i;
            }
            return -1;
        }
    }
}