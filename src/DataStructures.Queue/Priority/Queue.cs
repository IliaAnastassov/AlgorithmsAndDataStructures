using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue.Priority
{
    public class Queue<T> : IEnumerable<T>
    where T : IComparable<T>
    {
        private readonly LinkedList<T> _items = new LinkedList<T>();

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void Enqueue(T item)
        {
            if (_items.Count == 0)
            {
                _items.AddLast(item);
            }
            else
            {
                var current = _items.First;

                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    _items.AddLast(item);
                }
                else
                {
                    _items.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var item = _items.First.Value;

            _items.RemoveFirst();

            return item;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items.First.Value;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
