namespace SinglyLinkedList
{
    /// <summary>
    /// A node in the linked list.
    /// </summary>
    /// <typeparam name="T">The type of the value of the linked list node.</typeparam>
    public class LinkedListNode<T>
    {
        /// <summary>
        /// Constructs a new node with the specified value.
        /// </summary>
        /// <param name="value">The value of the linked list node.</param>
        public LinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The node value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The next node in the linked list or null if last node.
        /// </summary>
        public LinkedListNode<T> Next { get; set; }
    }
}
