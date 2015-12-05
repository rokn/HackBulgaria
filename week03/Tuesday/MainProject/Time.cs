using System;

namespace MainProject
{
    public class Time
    {
        private int seconds;
        private int minutes;
        private int hours;
        private int day;
        private int month;
        private int year;

        public int Seconds
        {
            get
            {
                return seconds;
            }
            private set
            {
                seconds = value;
                if (seconds < 0)
                    seconds = 0;
                if (seconds > 60)
                    seconds = 60;
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
            private set
            {
                minutes = value;
                if (minutes < 0)
                    minutes = 0;
                if (minutes > 60)
                    minutes = 60;
            }
        }

        public int Hours
        {
            get
            {
                return hours;
            }
            private set
            {
                hours = value;
                if (hours < 0)
                    hours = 0;
                if (hours > 24)
                    hours = 24;
            }
        }

        public int Day
        {
            get
            {
                return day;
            }
            private set
            {
                day = value;
                if (day < 0)
                    day = 0;
                int daysInMonth = GetMonthDays();
            }
        }

        public int Month
        {
            get
            {
                return month;
            }
            private set
            {
                month = value;
                if (month < 0)
                    month = 0;
                if (month > 12)
                    month = 12;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            private set
            {
                year = value;
                if (year < 1900)
                    year = 1900;
                if (year > 2100)
                    year = 2100;
            }
        }

        public Time()
            : this(0, 0, 0, 0, 0, 0)
        {
        }

        public Time(int year, int month, int day)
            : this(year, month, day, 0, 0, 0)
        {
        }

        public Time(int year, int month, int day, int hour, int minutes, int seconds)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.Hours = hour;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public int GetMonthDays()
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static Time Now
        {
            get 
            {
                DateTime now = DateTime.Now;
                Time nowTime = new Time(now.Year,now.Month,now.Day,now.Hour,now.Minute,now.Second);
                return nowTime;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}:{1}:{2} {3}.{4}.{5}", Hours, Minutes, Seconds, Day, Month, Seconds);
        }
    }
}
