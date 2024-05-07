using System;
using System.Collections.Generic;

namespace Stack
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(IsValid("{(((((((())))))))}"));
        }

        public static bool IsPalindrome(Node<int> head)
        {
            var list = new List<int>();
            for (var node = head; node != null; node = node.Next)
            {
                list.Add(node._data);
            }

            for (int i = 0; i < list.Count; i++)
            {
                var c1 = list[i];
                var c2 = list[list.Count - 1 - i];

                if (c1 != c2)
                    return false;
            }
            return true;
        }

        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    // Push opening brackets onto the stack
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        // No matching opening bracket
                        return false;
                    }

                    char top = stack.Pop();

                    // Check if the top of the stack matches the current closing bracket
                    if ((top == '(' && c != ')') || (top == '[' && c != ']') || (top == '{' && c != '}'))
                    {
                        return false;
                    }
                }
            }

            // If the stack is empty at the end, it means all opening brackets were properly matched and closed
            return true;
        }
    }
}