﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue.List
{
    /// <summary>
    /// A First In First Out collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private LinkedList<T> _items = new LinkedList<T>();

        /// <summary>
        /// Gets the number of items currently in the queue.
        /// </summary>
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        /// <summary>
        /// Adds the item to the back of the queue.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        /// <summary>
        /// Removes and returns the front item from the queue.
        /// </summary>
        /// <returns>The front item from the queue.</returns>
        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var item = _items.First.Value;

            _items.RemoveFirst();

            return item;
        }

        /// <summary>
        /// Returns the front item from the queue without removing it.
        /// </summary>
        /// <returns>The front item from the queue.</returns>
        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items.First.Value;
        }

        /// <summary>
        /// Removes all items from the queue.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the queue.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the queue.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}