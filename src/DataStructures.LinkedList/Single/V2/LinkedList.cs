using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.Single.V2
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> First { get; private set; }

        public LinkedListNode<T> Last { get; private set; }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public bool IsReadOnly => false;

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            var temp = First;
            First = node;
            First.Next = temp;

            if (IsEmpty)
            {
                Last = First;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (node.Next != null)
            {
                node = new LinkedListNode<T>(node.Value);
            }

            if (IsEmpty)
            {
                First = node;
            }
            else
            {
                Last.Next = node;
            }

            Last = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (!IsEmpty)
            {
                First = First.Next;
                Count--;

                if (Count == 0)
                {
                    Last = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (!IsEmpty)
            {
                if (Count == 1)
                {
                    First = null;
                    Last = null;
                }
                else
                {
                    var current = First;
                    while (current.Next != Last)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Last = current;
                }

                Count--;
            }
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public bool Contains(T item)
        {
            var current = First;
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
            var current = First;
            while (current != null)
            {
                array[arrayIndex] = current.Value;
                arrayIndex++;

                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = First;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Last = previous;
                        }

                        Count--;
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = First;
            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }
    }
}
