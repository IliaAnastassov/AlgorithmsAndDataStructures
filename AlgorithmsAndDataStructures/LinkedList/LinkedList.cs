namespace LinkedList
{
    class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(Node node)
        {
            var temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(Node node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
            Count++;
        }
    }
}
