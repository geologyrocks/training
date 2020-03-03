using System;
using Xunit;
using TimeLibrary;

namespace XUnitTests
{
    public class TimeXUnitTests_Ex1
    {
        // Test construction and accessors.
        [Fact]
        public void CreateTime_Midnight_ZeroHourMinuteSecond()
        {
            Time fixture = new Time();
            Assert.Equal(0, fixture.Hour);
            Assert.Equal(0, fixture.Minute);
            Assert.Equal(0, fixture.Second);
        }

        [Fact]
        public void CreateTime_SecondsIntoFirstMinute_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(0, 0, 5);
            Assert.Equal(0, fixture.Hour);
            Assert.Equal(0, fixture.Minute);
            Assert.Equal(5, fixture.Second);
        }

        [Fact]
        public void CreateTime_MinutesIntoFirstHour_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(0, 1, 5);
            Assert.Equal(0, fixture.Hour);
            Assert.Equal(1, fixture.Minute);
            Assert.Equal(5, fixture.Second);
        }

        [Fact]
        public void CreateTime_ExactHour_CorrectHourZeroMinuteZeroSecond()
        {
            Time fixture = new Time(23, 0, 0);
            Assert.Equal(23, fixture.Hour);
            Assert.Equal(0, fixture.Minute);
            Assert.Equal(0, fixture.Second);
        }

        [Fact]
        public void CreateTime_EndOfDay_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(23, 59, 59);
            Assert.Equal(23, fixture.Hour);
            Assert.Equal(59, fixture.Minute);
            Assert.Equal(59, fixture.Second);
        }

        // Test the math method.
        [Fact]
        public void Add_AddSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(12, 59, 59);
            fixture.Add(0, 0, 2);
            Assert.Equal(13, fixture.Hour);
            Assert.Equal(0, fixture.Minute);
            Assert.Equal(1, fixture.Second);
        }

        [Fact]
        public void Add_AddMinutesSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(12, 59, 59);
            fixture.Add(0, 2, 5);
            Assert.Equal(13, fixture.Hour);
            Assert.Equal(2, fixture.Minute);
            Assert.Equal(4, fixture.Second);
        }

        [Fact]
        public void Add_AddHoursMinutesSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(12, 59, 59);
            fixture.Add(1, 2, 5);
            Assert.Equal(14, fixture.Hour);
            Assert.Equal(2, fixture.Minute);
            Assert.Equal(4, fixture.Second);
        }

        [Fact]
        public void Subtract_SubtractSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(13, 0, 1);
            fixture.Subtract(0, 0, 2);
            Assert.Equal(12, fixture.Hour);
            Assert.Equal(59, fixture.Minute);
            Assert.Equal(59, fixture.Second);
        }

        [Fact]
        public void Subtract_SubtractMinutesSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(13, 2, 4);
            fixture.Subtract(0, 2, 5);
            Assert.Equal(12, fixture.Hour);
            Assert.Equal(59, fixture.Minute);
            Assert.Equal(59, fixture.Second);
        }

        [Fact]
        public void Subtract_SubtractHoursMinutesSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(14, 2, 4);
            fixture.Subtract(1, 2, 5);
            Assert.Equal(12, fixture.Hour);
            Assert.Equal(59, fixture.Minute);
            Assert.Equal(59, fixture.Second);
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
