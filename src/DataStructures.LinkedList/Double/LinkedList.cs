using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList.Double
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }

        public LinkedListNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public bool IsReadOnly => false;

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            var temp = Head;
            Head = node;
            Head.Next = temp;

            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
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
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (!IsEmpty)
            {
                Head = Head.Next;
                Count--;

                if (IsEmpty)
                {
                    Tail = null;
                }
                else
                {
                    Head.Previous = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (!IsEmpty)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
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
            var current = Head;
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
            var current = Head;
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
            LinkedListNode<T> current = Head;

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
                            Tail = previous;
                        }
                        else
                        {
                            current.Next.Previous = previous;
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
            var current = Head;
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
            Head = null;
            Tail = null;
            Count = 0;
        }
    }
}
