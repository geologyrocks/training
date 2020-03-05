using System;
using Xunit;
using TimeLibrary;

namespace TimeLibrary.UnitTests
{
    public class TimeLibraryUnitTests
    {
        [Fact]
        public void TimeLibrary_Initialises_With_0_Time()
        {
            int zeroTime = 0;
            Time time = new Time();
            Assert.True(time.Equals(zeroTime));
        }
    }
}
