using System.Threading;
using Xunit;

namespace ParallelizedTests
{
    public class TestClass1
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }
    }
}
