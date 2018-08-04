using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack.Array
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _size;

        /// <summary>
        /// Gets the number of items currently in the stack.
        /// </summary>
        public int Count
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the stack is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return _size == 0;
            }
        }

        /// <summary>
        /// Adds the item to the top of the stack.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Push(T item)
        {
            if (_size == _items.Length)
            {
                var newLenght = _size == 0 ? 4 : _size * 2;

                var temp = new T[newLenght];
                _items.CopyTo(temp, 0);
                _items = temp;
            }

            _items[_size] = item;
            _size++;
        }

        /// <summary>
        /// Removes and returns the top item from the stack.
        /// </summary>
        /// <returns>The top item from the stack.</returns>
        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            _size--;
            return _items[_size]; ;
        }

        /// <summary>
        /// Returns the top item from the stack without removing it.
        /// </summary>
        /// <returns>The top item from the stack.</returns>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _items[_size - 1];
        }

        /// <summary>
        /// Removes all items from the stack.
        /// </summary>
        public void Clear()
        {
            _items = new T[0];
            _size = 0;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the stack.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the stack.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the stack.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
