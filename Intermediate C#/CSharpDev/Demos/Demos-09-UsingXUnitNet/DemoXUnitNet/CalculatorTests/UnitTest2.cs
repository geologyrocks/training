using CalculatorLibrary;
using Xunit;

namespace CalculatorTests
{
    public class UnitTest2
    {
        [Theory]
        [InlineData(10.0, 20.0, 30.0)]
        [InlineData(10.0, -1.0, 9.0)]
        [InlineData(-1.0, -1.0, -2.0)]
        public void TestAdd(double param1, double param2, double expected)
        {
            // Arrange.
            Calculator c = new Calculator();

            // Act.
            double actual = c.Add(param1, param2);

            // Assert.
            Assert.Equal(expected, actual);
        }
    }
}
