using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stack.Array
{
    class Stack<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _topIndex;
        private int _stackDepth = 6;

        public void Push(T value)
        {
            if (_array == null)
            {
                _array = new T[_stackDepth];
                _topIndex = 0;
            }
            else
            {
                if (_topIndex == _array.Length - 1)
                {
                    _stackDepth *= 2;
                    var temp = new T[_stackDepth];
                    _array.CopyTo(temp, 0);
                    _array = temp;
                }

                _topIndex++;
            }

            _array[_topIndex] = value;
        }

        public T Peek()
        {
            if (_array == null || !_array.Any())
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _array[_topIndex];
        }

        public T Pop()
        {
            if (_array == null || !_array.Any())
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            var top = _array[_topIndex];
            _topIndex--;
            return top;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _array.Length - 1; i >= 0; i--)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
