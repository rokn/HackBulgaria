using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayscaleImages
{
    class GrayscaleImages
    {
        static void Main(string[] args)
        {
            Bitmap bmp = (Bitmap)Image.FromFile("test.bmp");
            ResampleImage(bmp, new Size(1000, 1000), "scale.bmp");
            GrayScaleImage(bmp, "Grayscale.bmp");
            BlurImage(bmp, "blurr2.bmp");
        }

        static void GrayScaleImage(Bitmap bitmap, string savepath)
        {
            Bitmap grayScale = (Bitmap)bitmap.Clone();

            for (int i = 0; i < grayScale.Width; i++)
            {
                for (int b = 0; b < grayScale.Height; b++)
                {
                    Color currColor = grayScale.GetPixel(i, b);
                    byte gray = (byte)(0.33 * currColor.R + 0.33 * currColor.G + 0.33 * currColor.B);
                    currColor = Color.FromArgb(gray, gray, gray);
                    grayScale.SetPixel(i, b, currColor);
                }
            }

            grayScale.Save(savepath);
        }

        static void ResampleImage(Bitmap bitmap, Size newSize, string savePath)
        {
            Bitmap scaled = new Bitmap(newSize.Width, newSize.Height);

            Size oldSize = bitmap.Size;
            float xFactor = (float)(newSize.Width - 1) / (float)(oldSize.Width - 1);
            float yFactor = (float)(newSize.Height - 1) / (float)(oldSize.Height - 1);

            for (int i = 0; i < newSize.Width; i++)
            {
                for (int b = 0; b < newSize.Height; b++)
                {
                    int x = (int)Math.Round(i / xFactor);
                    int y = (int)Math.Round(b / yFactor);

                    Color newColor = bitmap.GetPixel(x, y);
                    scaled.SetPixel(i, b, newColor);
                }
            }

            scaled.Save(savePath);
        }

        static void BlurImage(Bitmap bitmap, string savePath)
        {
            Bitmap blurred = (Bitmap)bitmap.Clone();
            List<Color> colors;

            for (int i = 0; i < blurred.Size.Width; i++)
            {
                for (int b = 0; b < blurred.Size.Height; b++)
                {
                    colors = GetPixels(blurred, i, b);
                    Color avrg = GetAverage(colors);
                    SetColors(blurred, i, b, avrg);
                    //blurred.SetPixel(i, b, avrg);
                }
            }

            blurred.Save(savePath);
        }

        static Color GetAverage(List<Color> colors)
        {
            int avrgR = 0;
            int avrgG = 0;
            int avrgB = 0;

            colors.ForEach(col => 
            {
                avrgR += col.R;
                avrgG += col.G;
                avrgB += col.B;
            });

            avrgR /= (int)colors.Count;
            avrgG /= (int)colors.Count;
            avrgB /= (int)colors.Count;

            return Color.FromArgb(avrgR,avrgG,avrgB);
        }

        static List<Color> GetPixels(Bitmap bitmap, int i, int b)
        {

            List<Color> colors = new List<Color>();
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if (PixelIsInside(i+x,b+y, bitmap.Size))
                    {
                        colors.Add(bitmap.GetPixel(i + x, b + y)); 
                    }
                }
            }

            return colors;
        }

        static void SetColors(Bitmap bitmap, int i, int b, Color color)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (PixelIsInside(i + x, b + y, bitmap.Size))
                    {
                        bitmap.SetPixel(i + x, b + y, color);
                    }
                }
            }
        }

        static bool PixelIsInside(int x, int y, Size size)
        {
            return x >= 0 && x < size.Width && y >= 0 && y < size.Height;
        }
    }
}