namespace LinkedList
{
    /// <summary>
    /// A node in the linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedListNode<T>
    {
        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The next node in the linked list (null if last node)
        /// </summary>
        public LinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Constructs a new node with the specified value
        /// </summary>
        /// <param name="value"></param>
        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
}
