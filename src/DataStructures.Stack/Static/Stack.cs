using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack.Static
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;
        private int _size;

        public Stack()
        {
            _items = new T[DEFAULT_CAPACITY];
            _size = 0;
        }

        public Stack(int capacity)
        {
            _items = new T[capacity];
            _size = 0;
        }

        public int Count => _size;

        public bool IsEmpty => _size == 0;

        public void Push(T item)
        {
            ExtendIfFull();

            _items[_size] = item;
            _size++;
        }

        public T Pop()
        {
            EnsureNotEmpty();
            _size--;
            var item = _items[_size];
            _items[_size] = default;

            return item;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _items[_size - 1];
        }

        public void Clear()
        {
            Array.Clear(_items, 0, _size);
            _size = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _size; i++)
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
            for (int i = _size - 1; i >= 0; i--)
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
            if (_size == _items.Length)
            {
                var extended = new T[_size * 2];
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
