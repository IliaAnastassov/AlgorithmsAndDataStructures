using System;

namespace DataStructures.LinkedList.Single.V1
{
    public class LinkedList<T>
    {
        private class LinkedListNode
        {
            public T Value { get; set; }

            public LinkedListNode Next { get; set; }

            public LinkedListNode(T value, LinkedListNode previous)
            {
                Value = value;
                previous.Next = this;
            }

            public LinkedListNode(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private int _size;
        private LinkedListNode _head;
        private LinkedListNode _tail;

        public int Count => _size;

        public LinkedList()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public void Add(T value)
        {
            if (_size == 0)
            {
                _head = new LinkedListNode(value);
                _tail = _head;
            }
            else
            {
                var newNode = new LinkedListNode(value, _tail);
                _tail = newNode;
            }

            _size++;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            // Find the node at the specified index
            var currentIndex = 0;
            var currentNode = _head;
            LinkedListNode previousNode = null;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            RemoveListNode(currentNode, previousNode);
        }

        public int Remove(T value)
        {
            // Find the node containing the searched value
            var currentIndex = 0;
            var currentNode = _head;
            LinkedListNode previousNode = null;

            while (currentNode != null)
            {
                if (Equals(currentNode.Value, value))
                {
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentNode != null)
            {
                // Node is found in the list -> remove it
                RemoveListNode(currentNode, previousNode);
                return currentIndex;
            }
            else
            {
                // Node is not found in the list -> return -1
                return -1;
            }
        }

        public int IndexOf(T value)
        {
            var index = 0;
            var currentNode = _head;

            while (currentNode != null)
            {
                if (Equals(currentNode.Value, value))
                {
                    return index;
                }

                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }

        public bool Contains(T value)
        {
            int index = IndexOf(value);
            return index != -1;
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                var node = GetNodeAt(index);
                return node.Value;
            }
            set
            {
                ValidateIndex(index);

                var node = GetNodeAt(index);
                node.Value = value;
            }
        }

        private void RemoveListNode(LinkedListNode node, LinkedListNode previous)
        {
            _size--;

            if (_size == 0)
            {
                // The list becomes empty -> remove head and tail
                _head = null;
                _tail = null;
            }
            else if (previous == null)
            {
                // The head node was removed -> update the head
                _head = node.Next;
            }
            else
            {
                // Redirect the pointers to skip the removed node
                previous.Next = node.Next;
            }

            // Fix the tail in case it was removed
            if (ReferenceEquals(_tail, node))
            {
                _tail = previous;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= _size || index < 0)
            {
                throw new IndexOutOfRangeException($"Index is out of range: {index}.");
            }
        }

        private LinkedListNode GetNodeAt(int index)
        {
            var currentNode = _head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
    }
}
