using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack.Static
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public Stack()
        {
            _items = new T[DEFAULT_CAPACITY];
            Count = 0;
        }

        public Stack(int capacity)
        {
            _items = new T[capacity];
            Count = 0;
        }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void Push(T item)
        {
            ExtendIfFull();

            _items[Count] = item;
            Count++;
        }

        public T Pop()
        {
            EnsureNotEmpty();
            Count--;
            var item = _items[Count];
            _items[Count] = default;

            return item;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _items[Count - 1];
        }

        public void Clear()
        {
            Array.Clear(_items, 0, Count);
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ExtendIfFull()
        {
            if (Count == _items.Length)
            {
                var extended = new T[Count * 2];
                _items.CopyTo(extended, 0);
                _items = extended;
            }
        }

        private void EnsureNotEmpty()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
        }
    }
}
