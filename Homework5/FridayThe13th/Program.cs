using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace DateTasks
{
    public static class Program
    {
        static void Main()
        {
            //Console.WriteLine(UnfortunateFridays(2014,2015));
            //PrintDatesWithGivenSum(2015,15);
            //HackerTime();


            //DateTime[] startDates = new DateTime[] { new DateTime(2000,1,1,12,10,0),
            //                                         new DateTime(2000,1,1,12,30,0),
            //                                         new DateTime(2000,1,1,12,15,0),
            //                                         new DateTime(2000,1,1,13,10,0),};
            //TimeSpan[] durations = new TimeSpan[] { new TimeSpan(0, 30, 0),
            //                                        new TimeSpan(0, 5, 0),
            //                                        new TimeSpan(0, 5, 0),
            //                                        new TimeSpan(0,30,0)};

            //FindIntersectingAppointments(startDates, durations);

            //PrintCalendar(11, 2015, new CultureInfo("bg-BG"));

            Console.WriteLine(GetBalance("pesho.txt", new DateTime(2015, 3, 26), new DateTime(2015, 3, 31), new CultureInfo("bg-BG")));
        }



        static int UnfortunateFridays(int startYear, int endYear)
        {
            DateTime date = new DateTime(startYear, 1, 13);
            int sum = 0;

            while (date.Year <= endYear)
            {
                if (date.DayOfWeek == DayOfWeek.Friday)
                {
                    sum++;
                }
                date = date.AddMonths(1);
            }

            return sum;
        }



        static void PrintDatesWithGivenSum(int year, int sum)
        {
            DateTime date = new DateTime(year, 1, 1);
            int currSum;
            while (date.Year == year)
            {
                currSum = DigitsSum(date.Year);
                currSum += DigitsSum(date.Month);
                currSum += DigitsSum(date.Day);

                if (currSum == sum)
                {
                    Console.WriteLine(date.ToString("dd/MM/yyyy") + ": {0}", sum);
                }

                date = date.AddDays(1);
            }
        }

        static int DigitsSum(int numb)
        {
            int sum = 0;

            while (numb > 0)
            {
                sum += numb % 10;
                numb /= 10;
            }

            return sum;
        }



        static void HackerTime()
        {
            DateTime now = DateTime.Now;
            DateTime hackTime = new DateTime(now.Year, 12, 21, 13, 37, 0);

            if (now > hackTime)
            {
                hackTime.AddYears(1);
            }

            TimeSpan remaining = hackTime - now;
            Console.WriteLine(remaining.ToString(@"dd\.hh\:mm"));
        }



        static void FindIntersectingAppointments(DateTime[] startDates, TimeSpan[] durations)
        {

            string format = "dd/MM/yyyy hh:mm";
            for (int i = 0; i < startDates.Length - 1; i++)
            {
                for (int b = i + 1; b < startDates.Length; b++)
                {
                    int intersectMinutes = DatesOverlapLength(startDates[i], durations[i], startDates[b], durations[b]);
                    if (intersectMinutes > 0)
                    {
                        Console.WriteLine("The appointment starting at {0} intersects the appointment starting at {1} with exactly {2} minutes.",
                            startDates[i].ToString(format),
                            startDates[b].ToString(format),
                            intersectMinutes);
                    }

                }
            }
        }

        static int DatesOverlapLength(DateTime start1, TimeSpan span1, DateTime start2, TimeSpan span2)
        {
            DateTime end1 = start1 + span1;
            DateTime end2 = start2 + span2;
            DateTime intersectStart;
            DateTime intersectEnd;

            if (start1 < start2)
            {
                intersectStart = start2;
            }
            else
            {
                intersectStart = start1;
            }

            if (end1 < end2)
            {
                intersectEnd = end1;
            }
            else
            {
                intersectEnd = end2;
            }


            if (intersectStart < intersectEnd)
            {
                return (intersectEnd - intersectStart).Minutes;
            }
            else
            {
                return 0;
            }
        }



        static void PrintCalendar(int month, int year, CultureInfo culture)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DateTime date = new DateTime(year, month, 1);
            Console.WriteLine(culture.DateTimeFormat.MonthNames[month - 1]);

            for (int i = 0; i < 7; i++)
            {
                Console.Write(culture.DateTimeFormat.DayNames[i] + " ");
            }

            Console.WriteLine();

            PrintStartOffset(date, culture);

            while (date.Month == month)
            {
                Console.Write("{0," + GetDayOfWeekLength(date.DayOfWeek, culture) + "} ", date.Day);
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    Console.WriteLine();
                }
                date = date.AddDays(1);
            }

            Console.WriteLine();
        }

        private static void PrintStartOffset(DateTime date, CultureInfo culture)
        {
            for (int i = 0; i < (int)date.DayOfWeek; i++)
            {
                Console.Write("{0" + (GetDayOfWeekLength((DayOfWeek)i, culture) + 1) + "}", ' ');
            }
        }

        static int GetDayOfWeekLength(DayOfWeek dayOfWeek, CultureInfo culture)
        {
            return culture.DateTimeFormat.DayNames[(int)dayOfWeek].ToString().Length;
        }



        static decimal GetBalance(string file, DateTime from, DateTime to, CultureInfo cultureInfo)
        {
            decimal balance = 0.0m;

            StreamReader reader = new StreamReader(file);
            DateTime currDate;
            decimal currAmount;
            bool payIn;

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (TryParseLine(line, out currDate, out payIn, out currAmount, cultureInfo))
                {
                    if (currDate >= from && currDate <= to)
                    {
                        if (payIn)
                        {
                            balance += currAmount;
                        }
                        else
                        {
                            balance -= currAmount;
                        }
                    }
                }
            }

            reader.Close();

            return balance;
        }

        static bool TryParseLine(string line, out DateTime date, out bool payIn, out decimal amount, CultureInfo cultureInfo)
        {
            date = new DateTime();
            payIn = false;
            amount = 0.0m;


            string[] splitted = line.Split(';');
            if (splitted.Length != 3)
            {
                return false;
            }

            string dateStr = splitted[0];
            string payInStr = splitted[1];
            string amountStr = splitted[2].Remove(splitted[2].Length - 2);

            if (!DateTime.TryParse(dateStr, cultureInfo, DateTimeStyles.AssumeLocal, out date))
            {
                return false;
            }

            switch (payInStr)
            {
                case "теглене":
                    payIn = false;
                    break;

                case "внасяне":
                    payIn = true;
                    break;

                default:
                    return false;
            }

            if (!decimal.TryParse(amountStr, NumberStyles.Currency, cultureInfo, out amount))
            {
                return false;
            }

            return true;
        }

        static string ToCurrency(float value, CultureInfo culture)
        {
            return value.ToString("c", culture);
        }
    }
}
