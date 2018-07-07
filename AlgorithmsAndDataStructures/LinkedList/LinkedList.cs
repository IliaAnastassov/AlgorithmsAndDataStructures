using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    /// <summary>
    /// A linked list collection.
    /// </summary>
    class LinkedList<T> : ICollection<T>
    {
        /// <summary>
        /// The first node in the linked list or null if empty.
        /// </summary>
        public LinkedListNode<T> Head { get; private set; }

        /// <summary>
        /// The last node in the linked list or null if empty.
        /// </summary>
        public LinkedListNode<T> Tail { get; private set; }

        /// <summary>
        /// The number of items currently in the linked list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the linked list is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Adds the specified value to the start of the linked list.
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Adds the node to the start of the linked list.
        /// </summary>
        /// <param name="node"></param>
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

        /// <summary>
        /// Adds the specified value to the end of the linked list.
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Adds the node to the end of the linked list.
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
        /// Removes the first node of the linked list.
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

        /// <summary>
        /// Removes the last node in the linked list.
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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = Head;
            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether the linked list contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the linked list</param>
        /// <returns>true if item is found in the linked list otherwise, false.</returns>
        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
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
