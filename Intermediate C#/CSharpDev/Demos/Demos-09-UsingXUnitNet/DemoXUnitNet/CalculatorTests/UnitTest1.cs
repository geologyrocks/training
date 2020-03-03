using Xunit;

namespace CalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void MyPassingTest()    
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void MyFailingTest()    
        {
            Assert.Equal(5, 2 + 2);
        }
    }
}
