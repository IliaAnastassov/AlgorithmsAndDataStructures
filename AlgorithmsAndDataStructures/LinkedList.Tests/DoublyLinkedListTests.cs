using DoublyLinkedList;
using NUnit.Framework;

namespace LinkedList.Tests
{
    [TestFixture]
    public class DoublyLinkedListTests
    {
        private LinkedList<int> sut;

        [SetUp]
        public void BeforeEachTest()
        {
            sut = new LinkedList<int>();
        }

        [TearDown]
        public void AfterEachTest()
        {
            // TODO
        }

        [Test]
        public void ShouldAddFirst()
        {
            sut.AddFirst(66);

            Assert.That(sut.First.Value, Is.EqualTo(66));
        }

        [Test]
        public void ShouldAddLast()
        {
            sut.AddLast(47);

            Assert.That(sut.Last.Value, Is.EqualTo(47));
        }

        [Test]
        public void ShouldRemoveFirst()
        {
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            sut.RemoveFirst();

            Assert.That(sut.First.Value, Is.EqualTo(2));
        }

        [Test]
        public void ShouldRemoveLast()
        {
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            sut.RemoveLast();

            Assert.That(sut.Last.Value, Is.EqualTo(2));
        }

        [Test]
        public void ShouldGetCount()
        {
            sut.Add(1);
            sut.Add(2);

            Assert.That(sut.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldClear()
        {
            sut.Add(1);
            sut.Add(2);

            sut.Clear();

            Assert.That(sut.Count, Is.EqualTo(0));
            Assert.That(sut.IsEmpty, Is.True);
        }

        [Test]
        public void ShouldNotBeEmpty()
        {
            sut.AddFirst(66);

            Assert.That(sut.IsEmpty, Is.False);
            Assert.That(sut.Count, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldBeEmpty()
        {
            var sut = new LinkedList<int>();

            Assert.That(sut.IsEmpty, Is.True);
            Assert.That(sut.Count, Is.EqualTo(0));
        }
    }
}
