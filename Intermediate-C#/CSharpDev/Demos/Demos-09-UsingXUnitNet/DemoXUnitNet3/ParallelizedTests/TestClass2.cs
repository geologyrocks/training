using System.Threading;
using Xunit;

namespace ParallelizedTests
{
    public class TestClass2
    {
        [Fact]
        public void Test2()
        {
            Thread.Sleep(5000);
        }
    }
}
