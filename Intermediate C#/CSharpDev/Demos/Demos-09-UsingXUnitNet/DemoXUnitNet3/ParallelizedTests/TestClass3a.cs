using System.Threading;
using Xunit;

namespace ParallelizedTests
{
    [Collection("MyCollection")]
    public class TestClass3a
    {
        [Fact]
        public void Test3a()
        {
            Thread.Sleep(3000);
        }
    }
}
