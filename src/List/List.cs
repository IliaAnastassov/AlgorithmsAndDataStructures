using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    public class List<T> : IEnumerable<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] _items;
        private int _count;

        public List()
        {
            _items = new T[INITIAL_CAPACITY];
            _count = 0;
        }

        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            GrowIfFullArray();

            _items[_count] = item;
            _count++;
        }

        public void Clear()
        {
            _items = new T[INITIAL_CAPACITY];
            _count = 0;
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

            Array.Copy(_items, index, _items, index + 1, _count - index);

            _items[index] = item;
            _count++;
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

            Array.Copy(_items, index + 1, _items, index, _count - index - 1);
            _items[_count - 1] = default;
            _count--;
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
            if (_count == _items.Length)
            {
                var extended = new T[_items.Length * 2];
                Array.Copy(_items, extended, _count);
                _items = extended;
            }
        }

        private void VerifyIndex(int index)
        {
            if (index >= _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
