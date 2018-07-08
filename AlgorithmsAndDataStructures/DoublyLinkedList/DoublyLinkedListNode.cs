namespace DoublyLinkedList
{
    /// <summary>
    /// A node in the linked list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DoublyLinkedListNode<T>
    {
        /// <summary>
        /// Constructs a new node with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The node value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The previous node in the linked list or null if last node.
        /// </summary>
        public DoublyLinkedListNode<T> Previous { get; set; }

        /// <summary>
        /// The next node in the linked list or null if last node.
        /// </summary>
        public DoublyLinkedListNode<T> Next { get; set; }
    }
}
