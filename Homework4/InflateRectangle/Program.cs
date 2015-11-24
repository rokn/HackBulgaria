using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflateRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(0, 0, 10, 10);
            Inflate(ref rect, new Size(2, 2));
            Console.WriteLine(rect.X);
            Console.WriteLine(rect.Y);
            Console.WriteLine(rect.Width);
            Console.WriteLine(rect.Height);
        }

        static void Inflate(ref Rectangle rect, Size inflateSize)
        {
            rect.X -= inflateSize.Width;
            rect.Width += inflateSize.Width*2;
            rect.Y -= inflateSize.Height;
            rect.Height += inflateSize.Height*2;
        }
    }
}
