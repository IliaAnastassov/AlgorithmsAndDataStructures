using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack.Array
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];

        /// <summary>
        /// Gets the number of items currently in the stack.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the stack is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        /// <summary>
        /// Adds the item to the top of the stack.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Push(T item)
        {
            if (Count == _items.Length)
            {
                var newLenght = Count == 0 ? 4 : Count * 2;

                var temp = new T[newLenght];
                _items.CopyTo(temp, 0);
                _items = temp;
            }

            _items[Count] = item;
            Count++;
        }

        /// <summary>
        /// Removes and returns the top item from the stack.
        /// </summary>
        /// <returns>The top item from the stack.</returns>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            Count--;
            return _items[Count]; ;
        }

        /// <summary>
        /// Returns the top item from the stack without removing it.
        /// </summary>
        /// <returns>The top item from the stack.</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _items[Count - 1];
        }

        /// <summary>
        /// Removes all items from the stack.
        /// </summary>
        public void Clear()
        {
            _items = new T[0];
            Count = 0;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the stack.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
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
