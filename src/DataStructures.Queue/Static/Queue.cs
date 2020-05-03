using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue.Static
{
    public class Queue<T> : IEnumerable<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;
        private int _head;
        private int _tail;
        private int _size;

        public Queue()
        {
            _items = new T[DEFAULT_CAPACITY];
            _head = 0;
            _tail = -1;
            _size = 0;
        }

        public int Count => _size;

        public void Enqueue(T item)
        {
            if (_size == _items.Length)
            {
                ExtendCapacity();
            }

            _items[_tail] = item;
            _items[_tail] = default;
            _tail = (_tail + 1) % _items.Length; // Set the tail to next index or 0, if tail at the end of the array
            _size++;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            var item = _items[_head];
            _items[_head] = default;
            _head = (_head + 1) % _items.Length; // Set the head to next index or 0, if head at the end of the array
            _size--;

            return item;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _items[_head];
        }

        public void Clear()
        {
            _items = new T[DEFAULT_CAPACITY];
            _head = 0;
            _tail = -1;
            _size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    for (int i = _head; i <= _tail; i++)
                    {
                        yield return _items[i];
                    }
                }
                else
                {
                    for (int i = _head; i < _items.Length; i++)
                    {
                        yield return _items[i];
                    }

                    for (int i = 0; i <= _tail; i++)
                    {
                        yield return _items[i];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Since Queue is circular, starting with array:
        ///     T/H
        /// [2|4|1|7]
        /// Results in array:
        ///  H       T
        /// [1|7|2|4| | | | ]
        /// </summary>
        private void ExtendCapacity()
        {
            var capacity = _items.Length * 2;
            var extended = new T[capacity];

            if (_head < _tail)
            {
                Array.Copy(_items, _head, extended, 0, _size);
            }
            else
            {
                Array.Copy(_items, _head, extended, 0, _items.Length - _head);
                Array.Copy(_items, 0, extended, _items.Length - _head, _tail);
            }

            _items = extended;
            _head = 0;
            _tail = _size;
        }

        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
        }
    }
}
