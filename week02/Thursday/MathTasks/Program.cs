using System;
using System.Drawing;
using System.IO;

namespace MathTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //PointF[] rect = new PointF[] { new PointF(0, 0), new PointF(0, 3), new PointF(3, 3), new PointF(3, 0) };

            //Console.WriteLine("Circumference: " + CalcCircumference(rect));
            //Console.WriteLine("Area: " + CalcArea(rect));
            //GenerateRandomMatrix(3, 3, "matrix.txt");
            Console.WriteLine(GetClockHandsAngle(6,30));
        }

        static float CalcCircumference(PointF[] points)
        {
            float circ = 0.0f;

            for (int i = 0; i < points.Length-1; i++)
            {
                circ += CalcDistance(points[i], points[i + 1]);
            }

            circ += CalcDistance(points[points.Length - 1], points[0]);

            return circ;
        }

        static float CalcDistance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(Math.Abs(p1.X - p2.X), 2) + Math.Pow(Math.Abs(p1.Y - p2.Y), 2));
        }

        static float CalcArea(PointF[] points)
        {
            float area = 0.0f;

            for (int i = 0; i < points.Length - 1; i++)
            {
                area += CalcPartialArea(points[i], points[i + 1]);
            }

            area += CalcPartialArea(points[points.Length - 1], points[0]);

            return area/2;
        }

        static float CalcPartialArea(PointF p1, PointF p2)
        {
            return (p1.X + p2.X) * (p1.Y - p2.Y);
        }

        static void GenerateRandomMatrix(int rows, int columns, string fileName)
        {

            Random rand = new Random();

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        writer.Write(string.Format("{0,8:0.00}", rand.NextDouble()*1000));
                    }
                    writer.WriteLine();
                }
            }
        }

        static int GetClockHandsAngle(int hours, int minutes)
        {
            hours = (hours > 12) ? hours - 12 : hours;
            int hoursAngle = (int)(30 * (hours + ((float)minutes / 60.0f)));
            int minutesAngle = 6 * minutes;
            int angle = Math.Abs(minutesAngle - hoursAngle);
            return Math.Min(angle, 360 - angle);
        }
    }
}
