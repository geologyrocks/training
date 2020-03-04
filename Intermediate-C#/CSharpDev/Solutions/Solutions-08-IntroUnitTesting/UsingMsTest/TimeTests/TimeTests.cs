using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLibrary;

namespace TimeTests
{
    [TestClass]
    public class TimeTests
    {
        // Test construction and accessors.
        [TestMethod]
        public void CreateTime_Midnight_ZeroHourMinuteSecond()
        {
            Time fixture = new Time();
            Assert.AreEqual(0, fixture.Hour);
            Assert.AreEqual(0, fixture.Minute);
            Assert.AreEqual(0, fixture.Second);
        }

        [TestMethod]
        public void CreateTime_SecondsIntoFirstMinute_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(0, 0, 5);
            Assert.AreEqual(0, fixture.Hour);
            Assert.AreEqual(0, fixture.Minute);
            Assert.AreEqual(5, fixture.Second);
        }

        [TestMethod]
        public void CreateTime_MinutesIntoFirstHour_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(0, 1, 5);
            Assert.AreEqual(0, fixture.Hour);
            Assert.AreEqual(1, fixture.Minute);
            Assert.AreEqual(5, fixture.Second);
        }

        [TestMethod]
        public void CreateTime_ExactHour_CorrectHourZeroMinuteZeroSecond()
        {
            Time fixture = new Time(23, 0, 0);
            Assert.AreEqual(23, fixture.Hour);
            Assert.AreEqual(0, fixture.Minute);
            Assert.AreEqual(0, fixture.Second);
        }

        [TestMethod]
        public void CreateTime_EndOfDay_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(23, 59, 59);
            Assert.AreEqual(23, fixture.Hour);
            Assert.AreEqual(59, fixture.Minute);
            Assert.AreEqual(59, fixture.Second);
        }

        // Test the math method.
        [TestMethod]
        public void Add_AddSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(12, 59, 59);
            fixture.Add(0, 0, 2);
            Assert.AreEqual(13, fixture.Hour);
            Assert.AreEqual(0, fixture.Minute);
            Assert.AreEqual(1, fixture.Second);
        }

        [TestMethod]
        public void Add_AddMinutesSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(12, 59, 59);
            fixture.Add(0, 2, 5);
            Assert.AreEqual(13, fixture.Hour);
            Assert.AreEqual(2, fixture.Minute);
            Assert.AreEqual(4, fixture.Second);
        }

        [TestMethod]
        public void Add_AddHoursMinutesSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(12, 59, 59);
            fixture.Add(1, 2, 5);
            Assert.AreEqual(14, fixture.Hour);
            Assert.AreEqual(2, fixture.Minute);
            Assert.AreEqual(4, fixture.Second);
        }

        [TestMethod]
        public void Subtract_SubtractSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(13, 0, 1);
            fixture.Subtract(0, 0, 2);
            Assert.AreEqual(12, fixture.Hour);
            Assert.AreEqual(59, fixture.Minute);
            Assert.AreEqual(59, fixture.Second);
        }

        [TestMethod]
        public void Subtract_SubtractMinutesSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(13, 2, 4);
            fixture.Subtract(0, 2, 5);
            Assert.AreEqual(12, fixture.Hour);
            Assert.AreEqual(59, fixture.Minute);
            Assert.AreEqual(59, fixture.Second);
        }

        [TestMethod]
        public void Subtract_SubtractHoursMinutesSeconds_CorrectHourMinuteSecond()
        {
            Time fixture = new Time(14, 2, 4);
            fixture.Subtract(1, 2, 5);
            Assert.AreEqual(12, fixture.Hour);
            Assert.AreEqual(59, fixture.Minute);
            Assert.AreEqual(59, fixture.Second);
        }

        // Test overrides from Object.
        [TestMethod]
        public void Equals_EqualObjects_ReturnsTrue()
        {
            Time t1 = new Time(12, 59, 59);
            Time t2 = new Time(12, 59, 59);
            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void Equals_DifferentHours_ReturnsFalse()
        {
            Time t1 = new Time(12, 59, 59);
            Time t2 = new Time(11, 59, 59);
            Assert.IsFalse(t1.Equals(t2));
        }

        [TestMethod]
        public void Equals_DifferentMinutes_ReturnsFalse()
        {
            Time t1 = new Time(12, 59, 59);
            Time t2 = new Time(12, 58, 59);
            Assert.IsFalse(t1.Equals(t2));
        }

        [TestMethod]
        public void Equals_DifferentSeconds_ReturnsFalse()
        {
            Time t1 = new Time(12, 59, 59);
            Time t2 = new Time(12, 59, 58);
            Assert.IsFalse(t1.Equals(t2));
        }

        [TestMethod]
        public void Equals_NonTime_ReturnsFalse()
        {
            Time t1 = new Time(12, 59, 59);
            String other = "wibble";
            Assert.IsFalse(t1.Equals(other));
        }

        [TestMethod]
        public void HashCode_CorrectHashCode()
        {
            Time t1 = new Time(1, 2, 3);
            int hashCode = t1.GetHashCode();
            Assert.AreEqual(3723, hashCode);
        }

        [TestMethod]
        public void ToString_Midnight_ReturnsAllZeros()
        {
            Time t1 = new Time();
            String str = t1.ToString();
            Assert.AreEqual("00:00:00", str);
        }

        [TestMethod]
        public void ToString_SmallNumbers_ReturnsZeroPaddedParts()
        {
            Time t1 = new Time(1, 2, 3);
            String str = t1.ToString();
            Assert.AreEqual("01:02:03", str);
        }

        [TestMethod]
        public void ToString_GeneralDate_ReturnsCorrectString()
        {
            Time t1 = new Time(10, 20, 30);
            String str = t1.ToString();
            Assert.AreEqual("10:20:30", str);
        }
    }
}
