using System.Threading;
using Xunit;

namespace ParallelizedTests
{
    [Collection("MyCollection")]
    public class TestClass3b
    {
        [Fact]
        public void Test3b()
        {
            Thread.Sleep(5000);
        }
    }
}
