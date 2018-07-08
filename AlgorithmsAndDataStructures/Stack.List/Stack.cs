using System.Collections;
using System.Collections.Generic;

namespace Stack.List
{
    class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> _list;

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
