using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.Array
{
    /// <summary>
    /// A First In First Out collection
    /// </summary>
    /// <typeparam name="T">The type of data stored in the queue</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _size = 0;
        private int _first = 0;
        private int _last = -1;

        /// <summary>
        /// Gets the number of items currently in the queue.
        /// </summary>
        public int Count
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// Adds the item to the back of the queue.
        /// </summary>
        /// <param name="item">The item to add.</param>
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

        /// <summary>
        /// Removes and returns the front item from the queue.
        /// </summary>
        /// <returns>The front item from the queue.</returns>
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

        /// <summary>
        /// Returns the front item from the queue without removing it.
        /// </summary>
        /// <returns>The front item from the queue.</returns>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items[_first];
        }

        /// <summary>
        /// Removes all items from the queue.
        /// </summary>
        public void Clear()
        {
            _size = 0;
            _first = 0;
            _last = -1;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the queue.</returns>
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

        /// <summary>
        /// Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the queue.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
