using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue.Dynamic
{
    public class Queue<T> : IEnumerable<T>
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
            _items.AddLast(item);
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
