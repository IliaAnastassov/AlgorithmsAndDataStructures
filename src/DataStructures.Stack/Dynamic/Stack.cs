using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack.Dynamic
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public int Count => _list.Count;

        public bool IsEmpty => _list.Count == 0;

        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        public T Pop()
        {
            EnsureNotEmpty();

            var top = _list.First.Value;
            _list.RemoveFirst();

            return top;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _list.First.Value;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
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
