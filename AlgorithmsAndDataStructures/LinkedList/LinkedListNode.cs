﻿namespace LinkedList
{
    class LinkedListNode<T>
    {
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Head { get; set; }

        public LinkedListNode<T> Tail { get; set; }

        public int Count { get; private set; }

        public void AddFirst(LinkedListNode<T> node)
        {
            var temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
            Count++;
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    var current = Head;
                    while (current.Next != Tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Tail = current;
                }

                Count--;
            }
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }
    }
}
