using System.Threading;
using Xunit;

namespace NonParallelizedTests
{
    public class TestClass
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }

        [Fact]
        public void Test2()
        {
            Thread.Sleep(5000);
        }
    }
}
 