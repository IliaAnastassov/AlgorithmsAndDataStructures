using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.Array
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _first = 0;
        private int _last = -1;

        public int Count { get; private set; } = 0;

        public void Enqueue(T item)
        {
            if (Count == _items.Length)
            {
                var newLenght = Count == 0 ? 4 : Count * 2;
                var newArray = new T[newLenght];

                if (Count > 0)
                {
                    var targetIndex = 0;

                    if (_last < _first)
                    {
                        for (int i = _first; i < _items.Length; i++)
                        {
                            newArray[targetIndex] = _items[i];
                            targetIndex++;
                        }

                        for (int i = 0; i < _first; i++)
                        {
                            newArray[targetIndex] = _items[i];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _items.Length; i++)
                        {
                            newArray[targetIndex] = _items[i];
                            targetIndex++;
                        }
                    }

                    _first = 0;
                    _last = targetIndex - 1;
                }
                else
                {
                    _first = 0;
                    _last = -1;
                }

                _items = newArray;
            }

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
            if (Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

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
            if (Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items[_first];
        }

        public void Clear()
        {
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
    }
}
