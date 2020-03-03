using System;

namespace TimeLibrary
{
    public class Time
    {
        private int secondsSinceMidnight;

        private const int SECONDS_PER_MINUTE = 60;
        private const int SECONDS_PER_HOUR = 3_600;

        // Constructors.
        public Time()
        {
            secondsSinceMidnight = 0;
        }

        public Time(int hours, int minutes, int seconds)
        {
            if (hours < 0 || hours > 23)
                throw new ArgumentException($"Invalid hour: {hours}");

            if (minutes < 0 || minutes > 59)
                throw new ArgumentException($"Invalid minute: {minutes}");

            if (seconds < 0 || seconds > 59)
                throw new ArgumentException($"Invalid second: {seconds}");

            secondsSinceMidnight = ToSeconds(hours, minutes, seconds);
        }

        // Accessor properties, using "expression bodied properties" introduced in C# 7.0.
        public int Hour
        {
            get => secondsSinceMidnight / SECONDS_PER_HOUR;
        }

        public int Minute
        {
            get => (secondsSinceMidnight % SECONDS_PER_HOUR) / SECONDS_PER_MINUTE;
        }

        public int Second
        {
            get => (secondsSinceMidnight % SECONDS_PER_HOUR) % SECONDS_PER_MINUTE;
        }

        // Math methods.
        public void Add(int hours, int minutes, int seconds)
        {
            secondsSinceMidnight += ToSeconds(hours, minutes, seconds);
        }

        public void Subtract(int hours, int minutes, int seconds)
        {
            secondsSinceMidnight -= ToSeconds(hours, minutes, seconds);
        }

        // Overrides from Object.
        public override bool Equals(Object other)
        {
            Time otherTime = other as Time;
            if (otherTime == null)
                return false;
            else
                return secondsSinceMidnight == otherTime.secondsSinceMidnight;
        }

        public override int GetHashCode()
        {
            return secondsSinceMidnight;
        }

        public override String ToString()
        {
            return $"{Hour:D2}:{Minute:D2}:{Second:D2}";
        }

        // Internal helper method...
        private static int ToSeconds(int hours, int minutes, int seconds)
        {
            return hours * SECONDS_PER_HOUR + minutes * SECONDS_PER_MINUTE + seconds;
        }
    }
}
