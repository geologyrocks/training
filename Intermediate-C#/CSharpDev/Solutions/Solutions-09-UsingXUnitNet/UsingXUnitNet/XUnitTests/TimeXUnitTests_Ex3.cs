using System;
using Xunit;
using TimeLibrary;

namespace XUnitTests
{
    public class TimeXUnitTests_Ex3
    {
        private Time mathFixture;

        public TimeXUnitTests_Ex3()
        {
            mathFixture = new Time(12, 59, 59);
        }

        private void AssertHms(int h, int m, int s, Time fixture)
        {
            Assert.Equal(h, fixture.Hour);
            Assert.Equal(m, fixture.Minute);
            Assert.Equal(s, fixture.Second);
        }

        // Test construction and accessors.
        [Fact]
        public void CreateTime_Midnight_ZeroHourMinuteSecond()
        {
            Time fixture = new Time();
            AssertHms(0, 0, 0, fixture);
        }

        [Fact]
        public void CreateTime_SecondsIntoFirstMinute_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(0, 0, 5);
            AssertHms(0, 0, 5, fixture);
        }

        [Fact]
        public void CreateTime_MinutesIntoFirstHour_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(0, 1, 5);
            AssertHms(0, 1, 5, fixture);
        }

        [Fact]
        public void CreateTime_ExactHour_CorrectHourZeroMinuteZeroSecond()
        {
            Time fixture = new Time(23, 0, 0);
            AssertHms(23, 0, 0, fixture);
        }

        [Fact]
        public void CreateTime_EndOfDay_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(23, 59, 59);
            AssertHms(23, 59, 59, fixture);
        }

        // Test the Add method with various values.
        [Theory]
        [InlineData(0, 0, 2, 13, 0, 1)]
        [InlineData(0, 2, 5, 13, 2, 4)]
        [InlineData(1, 2, 5, 14, 2, 4)]
        public void Add_AddHms_CorrectHms(int addH, int addM, int addS, int expH, int expM, int expS)
        {
            mathFixture.Add(addH, addM, addS);
            AssertHms(expH, expM, expS, mathFixture);
        }

        // Test the Subtract method with various values.
        [Theory]
        [InlineData(0, 0, 2, 12, 59, 57)]
        [InlineData(0, 2, 5, 12, 57, 54)]
        [InlineData(1, 61, 61, 10, 57, 58)]
        public void Subtract_SubtractHms_CorrectHms(int subH, int subM, int subS, int expH, int expM, int expS)
        {
            mathFixture.Subtract(subH, subM, subS);
            AssertHms(expH, expM, expS, mathFixture);
        }

        // Test overrides from Object.
        [Fact]
        public void Equals_EqualObjects_ReturnsTrue()
        {
            Time t1 = new Time(12, 59, 59);
            Time t2 = new Time(12, 59, 59);
            Assert.True(t1.Equals(t2));
        }

        [Fact]
        public void Equals_DifferentHours_ReturnsFalse()
        {
            Time t1 = new Time(12, 59, 59);
            Time t2 = new Time(11, 59, 59);
            Assert.False(t1.Equals(t2));
        }

        [Fact]
        public void Equals_DifferentMinutes_ReturnsFalse()
        {
            Time t1 = new Time(12, 59, 59);
            Time t2 = new Time(12, 58, 59);
            Assert.False(t1.Equals(t2));
        }

        [Fact]
        public void Equals_DifferentSeconds_ReturnsFalse()
        {
            Time t1 = new Time(12, 59, 59);
            Time t2 = new Time(12, 59, 58);
            Assert.False(t1.Equals(t2));
        }

        [Fact]
        public void Equals_NonTime_ReturnsFalse()
        {
            Time t1 = new Time(12, 59, 59);
            String other = "wibble";
            Assert.False(t1.Equals(other));
        }

        [Fact]
        public void HashCode_CorrectHashCode()
        {
            Time t1 = new Time(1, 2, 3);
            int hashCode = t1.GetHashCode();
            Assert.Equal(3723, hashCode);
        }

        [Fact]
        public void ToString_Midnight_ReturnsAllZeros()
        {
            Time t1 = new Time();
            String str = t1.ToString();
            Assert.Equal("00:00:00", str);
        }

        [Fact]
        public void ToString_SmallNumbers_ReturnsZeroPaddedParts()
        {
            Time t1 = new Time(1, 2, 3);
            String str = t1.ToString();
            Assert.Equal("01:02:03", str);
        }

        [Fact]
        public void ToString_GeneralDate_ReturnsCorrectString()
        {
            Time t1 = new Time(10, 20, 30);
            String str = t1.ToString();
            Assert.Equal("10:20:30", str);
        }
    }
}
