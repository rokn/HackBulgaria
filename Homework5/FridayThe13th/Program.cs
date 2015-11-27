﻿using System;

namespace DateTasks
{
    public static class Program
    {
        static void Main()
        {
            //Console.WriteLine(UnfortunateFridays(2014,2015));
            //PrintDatesWithGivenSum(2015,15);
            //HackerTime();
            DateTime[] startDates = new DateTime[] { new DateTime(2000,1,1,12,10,0),
                                                     new DateTime(2000,1,1,12,30,0),
                                                     new DateTime(2000,1,1,12,15,0),
                                                     new DateTime(2000,1,1,13,10,0),};
            TimeSpan[] durations = new TimeSpan[] { new TimeSpan(0, 30, 0),
                                                    new TimeSpan(0, 5, 0),
                                                    new TimeSpan(0, 5, 0),
                                                    new TimeSpan(0,30,0)};

            FindIntersectingAppointments(startDates, durations);
        }

        static int UnfortunateFridays(int startYear, int endYear)
        {
            DateTime date = new DateTime(startYear, 1, 13);
            int sum = 0;

            while (date.Year <= endYear)
            {
                if(date.DayOfWeek == DayOfWeek.Friday)
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

                if(currSum == sum)
                {
                    Console.WriteLine(date.ToString("dd/MM/yyyy") + ": {0}", sum);
                }

                date = date.AddDays(1);
            }
        }

        static int DigitsSum(int numb)
        {
            int sum = 0;
            
            while(numb > 0)
            {
                sum += numb % 10;
                numb /= 10;
            }

            return sum;
        }

        static void HackerTime()
        {
            DateTime now = DateTime.Now;
            DateTime hackTime = new DateTime(now.Year,12,21,13,37,0);

            if(now > hackTime)
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
                    if(intersectMinutes > 0)
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


            if(intersectStart < intersectEnd)
            {
                return (intersectEnd - intersectStart).Minutes;
            }
            else
            {
                return 0;
            }
        }
    }
}
