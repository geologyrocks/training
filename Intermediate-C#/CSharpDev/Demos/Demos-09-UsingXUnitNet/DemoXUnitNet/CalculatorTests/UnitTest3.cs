using CalculatorLibrary;
using System.Collections.Generic;
using Xunit;

namespace CalculatorTests
{
    public class UnitTest3
    {
        [Theory]
        [MemberData(nameof(CalcTestData.TestData), MemberType = typeof(CalcTestData))]
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
    
    public class CalcTestData
    {
        public static List<object[]> TestData => new List<object[]>
        {
            new object[] { 5.0, 10.0, 15.0 },
            new object[] { -5.0, -10.0, -15.0 },
            new object[] { 0.0, 0.0, 0.0 }
        };
    }
}
