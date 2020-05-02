using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack.Array
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

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

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            Count--;
            return _items[Count]; ;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _items[Count - 1];
        }

        public void Clear()
        {
            _items = new T[0];
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
