using System;

namespace GeometryFigures
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestGeometry();
        }

        static void TestGeometry()
        {
            Rectangle rect1 = new Rectangle(new Point(0, 0), new Point(3, 3));
            Rectangle rect2 = new Rectangle(new Point(6, 6), new Point(-3, 3));

            Console.WriteLine(rect1.ToString());
            Console.WriteLine(rect1.GetPerimeter());
            Console.WriteLine(rect1.GetArea());
            Console.WriteLine(rect1.Bottom);
            Console.WriteLine(rect1.Center);
            Console.WriteLine(rect1.DownLeft);
            Console.WriteLine(rect1.DownRight);
            Console.WriteLine(rect1.Height);
            Console.WriteLine(rect1.Width);
            Console.WriteLine(rect1.Left);
            Console.WriteLine(rect1.Right);
            Console.WriteLine(rect1.Top);
            Console.WriteLine(rect1.UpLeft);
            Console.WriteLine(rect1.UpRight);

            Console.WriteLine(rect2.ToString());
            Console.WriteLine(rect2.GetPerimeter());
            Console.WriteLine(rect2.GetArea());
            Console.WriteLine(rect2.Bottom);
            Console.WriteLine(rect2.Center);
            Console.WriteLine(rect2.DownLeft);
            Console.WriteLine(rect2.DownRight);
            Console.WriteLine(rect2.Height);
            Console.WriteLine(rect2.Width);
            Console.WriteLine(rect2.Left);
            Console.WriteLine(rect2.Right);
            Console.WriteLine(rect2.Top);
            Console.WriteLine(rect2.UpLeft);
            Console.WriteLine(rect2.UpRight);


            Console.WriteLine(rect1.Equals(rect2));
        }
    }
}
