using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    public class List<T> : IEnumerable<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] _items;

        public List()
        {
            _items = new T[INITIAL_CAPACITY];
            Count = 0;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            GrowIfFullArray();

            _items[Count] = item;
            Count++;
        }

        public void Clear()
        {
            _items = new T[INITIAL_CAPACITY];
            Count = 0;
        }

        public bool Contains(T item)
        {
            var index = IndexOf(item);
            return index != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (item.Equals(_items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            VerifyIndex(index);
            GrowIfFullArray();

            Array.Copy(_items, index, _items, index + 1, Count - index);

            _items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            VerifyIndex(index);

            Array.Copy(_items, index + 1, _items, index, Count - index - 1);
            _items[Count - 1] = default;
            Count--;
        }

        public T this[int index]
        {
            get
            {
                VerifyIndex(index);
                return _items[index];
            }
            set
            {
                VerifyIndex(index);
                _items[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        private void GrowIfFullArray()
        {
            if (Count == _items.Length)
            {
                var extended = new T[_items.Length * 2];
                Array.Copy(_items, extended, Count);
                _items = extended;
            }
        }

        private void VerifyIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
