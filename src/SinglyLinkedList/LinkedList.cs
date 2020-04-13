using System.Collections;
using System.Collections.Generic;

namespace SinglyLinkedList
{
    /// <summary>
    /// A linked list collection.
    /// </summary>
    public class LinkedList<T> : ICollection<T>
    {
        /// <summary>
        /// The first node in the linked list or null if empty.
        /// </summary>
        public LinkedListNode<T> First { get; private set; }

        /// <summary>
        /// The last node in the linked list or null if empty.
        /// </summary>
        public LinkedListNode<T> Last { get; private set; }

        /// <summary>
        /// The number of items currently in the linked list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the linked list is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the linked list is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Adds the specified value to the start of the linked list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Adds the node to the start of the linked list.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public void AddFirst(LinkedListNode<T> node)
        {
            var temp = First;
            First = node;
            First.Next = temp;

            if (IsEmpty)
            {
                Last = First;
            }

            Count++;
        }

        /// <summary>
        /// Adds the specified value to the end of the linked list.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Adds the node to the end of the linked list.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public void AddLast(LinkedListNode<T> node)
        {
            if (node.Next != null)
            {
                node = new LinkedListNode<T>(node.Value);
            }

            if (IsEmpty)
            {
                First = node;
            }
            else
            {
                Last.Next = node;
            }

            Last = node;
            Count++;
        }

        /// <summary>
        /// Removes the first node of the linked list.
        /// </summary>
        public void RemoveFirst()
        {
            if (!IsEmpty)
            {
                First = First.Next;
                Count--;

                if (Count == 0)
                {
                    Last = null;
                }
            }
        }

        /// <summary>
        /// Removes the last node in the linked list.
        /// </summary>
        public void RemoveLast()
        {
            if (!IsEmpty)
            {
                if (Count == 1)
                {
                    First = null;
                    Last = null;
                }
                else
                {
                    var current = First;
                    while (current.Next != Last)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Last = current;
                }

                Count--;
            }
        }

        /// <summary>
        /// Adds an item to the linked list.
        /// </summary>
        /// <param name="item">The object to add to the linked list.</param>
        public void Add(T item)
        {
            AddFirst(item);
        }

        /// <summary>
        /// Determines whether the linked list contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the linked list</param>
        /// <returns>true if item is found in the linked list otherwise, false.</returns>
        public bool Contains(T item)
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Copies the elements of the linked list to an System.Array, starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied
        /// from the linked list. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = First;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the linked list.
        /// </summary>
        /// <param name="item">The object to remove from the linked list.</param>
        /// <returns>true if item was successfully removed from the linked list; otherwise, false.
        /// This method also returns false if item is not found in the original linked list.</returns>
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = First;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Last = previous;
                        }

                        Count--;
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the linked list.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the linked list.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = First;
            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the linked list.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the linked list.</returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        /// <summary>
        /// Removes all items from the linked list.
        /// </summary>
        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }
    }
}
