using System;

namespace DataStructures.LinkedList.Single.V1
{
    public class LinkedList<T>
    {
        private class LinkedListNode
        {
            public T Element { get; set; }

            public LinkedListNode Next { get; set; }

            public LinkedListNode(T element, LinkedListNode previous)
            {
                Element = element;
                previous.Next = this;
            }

            public LinkedListNode(T element)
            {
                Element = element;
                Next = null;
            }
        }

        private LinkedListNode _head;
        private LinkedListNode _tail;

        public int Count { get; private set; }

        public LinkedList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count == 0)
            {
                _head = new LinkedListNode(item);
                _tail = _head;
            }
            else
            {
                var newNode = new LinkedListNode(item, _tail);
                _tail = newNode;
            }

            Count++;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            // Find the element at the specified index
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

        public int Remove(T item)
        {
            // Find the element containing the searched item
            var currentIndex = 0;
            var currentNode = _head;
            LinkedListNode previousNode = null;

            while (currentNode != null)
            {
                if (Equals(currentNode.Element, item))
                {
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentNode != null)
            {
                // Element is found in the list -> remove it
                RemoveListNode(currentNode, previousNode);
                return currentIndex;
            }
            else
            {
                // Element is not found in the list -> return -1
                return -1;
            }
        }

        public int IndexOf(T item)
        {
            var index = 0;
            var currentNode = _head;

            while (currentNode != null)
            {
                if (Equals(currentNode.Element, item))
                {
                    return index;
                }

                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }

        public bool Contains(T item)
        {
            int index = IndexOf(item);
            return index != -1;
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                var node = GetNodeAt(index);
                return node.Element;
            }
            set
            {
                ValidateIndex(index);

                var node = GetNodeAt(index);
                node.Element = value;
            }
        }

        private void RemoveListNode(LinkedListNode node, LinkedListNode previous)
        {
            Count--;

            if (Count == 0)
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
            if (index >= Count || index < 0)
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
