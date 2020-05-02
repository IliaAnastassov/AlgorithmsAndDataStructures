using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue.Static
{
    public class Queue<T> : IEnumerable<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;
        private int _first;
        private int _last;

        public Queue()
        {
            _items = new T[DEFAULT_CAPACITY];
            _first = 0;
            _last = -1;
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            ExtendIfFull();

            if (_last == _items.Length - 1)
            {
                _last = 0;
            }
            else
            {
                _last++;
            }

            _items[_last] = item;
            Count++;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            var item = _items[_first];

            if (_first == _items.Length - 1)
            {
                _first = 0;
            }
            else
            {
                _first++;
            }

            Count--;

            return item;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _items[_first];
        }

        public void Clear()
        {
            _items = new T[DEFAULT_CAPACITY];
            Count = 0;
            _first = 0;
            _last = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Count > 0)
            {
                if (_last < _first)
                {
                    for (int i = _first; i < _items.Length; i++)
                    {
                        yield return _items[i];
                    }

                    for (int i = 0; i <= _last; i++)
                    {
                        yield return _items[i];
                    }
                }
                else
                {
                    for (int i = _first; i <= _last; i++)
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

        private void ExtendIfFull()
        {
            if (Count == _items.Length)
            {
                var extended = new T[Count * 2];
                var targetIndex = 0;

                if (_last < _first)
                {
                    for (int i = _first; i < _items.Length; i++)
                    {
                        extended[targetIndex] = _items[i];
                        targetIndex++;
                    }

                    for (int i = 0; i < _first; i++)
                    {
                        extended[targetIndex] = _items[i];
                        targetIndex++;
                    }
                }
                else
                {
                    for (int i = 0; i < _items.Length; i++)
                    {
                        extended[targetIndex] = _items[i];
                        targetIndex++;
                    }
                }

                _first = 0;
                _last = targetIndex - 1;

                _items = extended;
            }
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
