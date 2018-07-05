using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    /// <summary>
    /// A linked list collection
    /// </summary>
    class LinkedList<T> : ICollection<T>
    {
        /// <summary>
        /// The first node in the linked list (null if empty)
        /// </summary>
        public LinkedListNode<T> Head { get; set; }

        /// <summary>
        /// The last node in the linked list (null if empty)
        /// </summary>
        public LinkedListNode<T> Tail { get; set; }

        /// <summary>
        /// The number of nodes in the linked list
        /// </summary>
        public int Count { get; private set; }

        public bool IsReadOnly => throw new System.NotImplementedException();

        /// <summary>
        /// Adds a node to he front of the linked list
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
        }

        /// <summary>
        /// Adds a node to the end of the linked list
        /// </summary>
        /// <param name="node"></param>
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

        /// <summary>
        /// Removes the last node in the linked list
        /// </summary>
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
                    LinkedListNode<T> current = Head;
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

        /// <summary>
        /// Removes the first node of the linked list
        /// </summary>
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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
