using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new Node { Value = 3 };
            var middle = new Node { Value = 5 };
            var last = new Node { Value = 7 };

            first.Next = middle;
            middle.Next = last;

            PrintList(first);
        }

        private static void PrintList(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
