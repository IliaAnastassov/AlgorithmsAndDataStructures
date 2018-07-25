using NUnit.Framework;
using SinglyLinkedList;

namespace LinkedList.Tests
{
    [TestFixture]
    class SinglyLinkedListTests
    {
        [Test]
        public void ShouldAddFirst()
        {
            var sut = new LinkedList<int>();

            sut.AddFirst(66);
            sut.AddLast(42);
            sut.AddLast(47);

            Assert.That(sut.First.Value, Is.EqualTo(66));
        }

        [Test]
        public void ShouldAddLast()
        {
            var sut = new LinkedList<int>();

            sut.AddFirst(66);
            sut.AddLast(42);
            sut.AddLast(47);

            Assert.That(sut.Last.Value, Is.EqualTo(47));
        }

        [Test]
        public void ShouldRemoveFirst()
        {
            var sut = new LinkedList<int>
            {
                3, 2, 1
            };

            sut.RemoveFirst();

            Assert.That(sut.First.Value, Is.EqualTo(2));
        }

        [Test]
        public void ShouldRemoveLast()
        {
            var sut = new LinkedList<int>
            {
                3, 2, 1
            };

            sut.RemoveLast();

            Assert.That(sut.Last.Value, Is.EqualTo(2));
        }
    }
}
