using NUnit.Framework;
using Stack.List;
using System;

namespace Stack.Tests
{
    [TestFixture]
    public class StackListTests
    {
        private Stack<int> sut;

        [SetUp]
        public void BeforeEachTest()
        {
            sut = new Stack<int>();
        }

        [Test]
        public void ShouldPush()
        {
            sut.Push(1);

            Assert.That(sut.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldPop()
        {
            sut.Push(1);

            Assert.That(sut.Pop(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldPeek()
        {
            sut.Push(1);

            Assert.That(sut.Peek(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldClear()
        {
            sut.Push(1);
            sut.Push(2);
            sut.Push(3);

            sut.Clear();

            Assert.That(sut.Count, Is.EqualTo(0));
            Assert.Throws<InvalidOperationException>(() => sut.Pop(), "The stack is empty.");
        }

        [Test]
        public void ShouldThrowExceptionWhenEmptyOnPop()
        {
            Assert.Throws<InvalidOperationException>(() => sut.Pop(), "The stack is empty.");
        }

        [Test]
        public void ShouldThrowExceptionWhenEmptyOnPeek()
        {
            Assert.Throws<InvalidOperationException>(() => sut.Peek(), "The stack is empty.");
        }
    }
}
