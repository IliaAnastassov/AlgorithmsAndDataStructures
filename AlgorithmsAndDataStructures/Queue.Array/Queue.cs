using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.Array
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _size = 0;
        private int _first = 0;
        private int _last = -1;

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Enqueue(T item)
        {
            if (_size == _items.Length)
            {
                var newLenght = _size == 0 ? 4 : _size * 2;
                var newArray = new T[newLenght];

                if (_size > 0)
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
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
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

            _size--;

            return item;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items[_first];
        }

        public void Clear()
        {
            _size = 0;
            _first = 0;
            _last = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
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
