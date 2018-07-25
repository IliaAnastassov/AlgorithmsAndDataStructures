using NUnit.Framework;

namespace LinkedList.Tests
{
    [TestFixture]
    class SinglyLinkedListTests
    {
        [Test]
        public void ShouldAddFirst()
        {
            var sut = new SinglyLinkedList.LinkedList<int>();

            sut.AddFirst(66);
            sut.AddLast(42);
            sut.AddLast(47);

            Assert.That(sut.Head.Value, Is.EqualTo(66));
        }

        [Test]
        public void ShouldAddLast()
        {
            var sut = new SinglyLinkedList.LinkedList<int>();

            sut.AddFirst(66);
            sut.AddFirst(42);
            sut.AddLast(47);

            Assert.That(sut.Tail.Value, Is.EqualTo(47));
        }
    }
}
