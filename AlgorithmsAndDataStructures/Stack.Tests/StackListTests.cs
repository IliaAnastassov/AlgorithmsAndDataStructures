using NUnit.Framework;
using Stack.List;

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

        }
    }
}
