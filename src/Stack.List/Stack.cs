using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack.List
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        /// <summary>
        /// Gets the number of items currently in the stack.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets a value indicating whether the stack is empty.
        /// </summary>
        public bool IsEmpty => _list.Count == 0;

        /// <summary>
        /// Adds the item to the top of the stack.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        /// <summary>
        /// Removes and returns the top item from the stack.
        /// </summary>
        /// <returns>The top item from the stack.</returns>
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            var top = _list.First.Value;
            _list.RemoveFirst();

            return top;
        }

        /// <summary>
        /// Returns the top item from the stack without removing it.
        /// </summary>
        /// <returns>The top item from the stack.</returns>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _list.First.Value;
        }

        /// <summary>
        /// Removes all items from the stack.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the stack.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the stack.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the stack.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
