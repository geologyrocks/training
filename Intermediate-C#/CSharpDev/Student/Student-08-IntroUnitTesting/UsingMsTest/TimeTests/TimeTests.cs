using System;
using Xunit;
using FluentAssertions;

namespace TimeLibrary.UnitTests
{
    public class TimeLibraryUnitTests
    {
        [Fact]
        public void TimeLibrary_Initialises_With_0_Time()
        {
            int zeroTime = 0;
            Time time = new Time();
            Assert.Equal(zeroTime, time.Hour);
            Assert.Equal(zeroTime, time.Minute);
            Assert.Equal(zeroTime, time.Second);
        }

        [Fact]
        public void TimeLibrary_Add_IncreasesTimeBySpecifiedAmount()
        {
            // Arrange
            Time time = new Time();

            // Act
            time.Add(0,0,30);

            // Assert
            time.Second.Should().Be(30);
        }

    }
}
