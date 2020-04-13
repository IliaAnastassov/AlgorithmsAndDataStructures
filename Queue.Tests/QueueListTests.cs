using NUnit.Framework;
using Queue.List;

namespace Queue.Tests
{
    [TestFixture]
    public class QueueListTests
    {
        private Queue<int> sut;

        [SetUp]
        public void BeforeEachTest()
        {
            sut = new Queue<int>();
        }
    }
}
