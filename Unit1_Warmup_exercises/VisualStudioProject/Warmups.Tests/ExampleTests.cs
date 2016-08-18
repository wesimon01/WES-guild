using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class ExampleTests
    {
        [TestCase(1,1,2)]
        [TestCase(5,10,15)]
        public void AddTest(int x, int y, int expected)
        {
            // arrange, instantiate object
            Example obj = new Example();

            // act, call the method
            int actual = obj.Add(x, y);

            // assert, verify correctness
            Assert.AreEqual(expected, actual);
        }
    }
}
