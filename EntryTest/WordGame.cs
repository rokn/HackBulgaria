using System;
using System.Collections.Generic;

namespace WordGame
{
    public class Program
    {
        static List<string> table;
        static int rowLength = -1;
        static string searchString;

        static void Main(string[] args)
        {
            table = new List<string>();
            string currentRow;
            int hits = 0;

            Console.WriteLine("What is the string you'll be looking for :");
            searchString = Console.ReadLine().ToLower();

            Console.WriteLine("Input table rows of the same length\nInput 'stop'(with quotation marks) to stop inputing");

            do
            {
                currentRow = Console.ReadLine();                
                
                if(rowLength == -1)
                {
                    rowLength = currentRow.Length;
                }

                if (currentRow != "'stop'")
                {
                    if (currentRow.Length == rowLength)
                    {
                        table.Add(currentRow.ToLower());
                    }
                    else
                    {
                        Console.WriteLine("Wrong row length please input a row with correct length");
                    }
                }

            } while (currentRow != "'stop'");

            for (int i = 0; i < table.Count; i++)
            {
                for (int b = 0; b < table[i].Length; b++)
                {
                    if (table[i][b] == searchString[0])
                    {
                        hits += CheckHorizontaly(i, b);
                        hits += CheckVertically(i, b);
                        hits += CheckDiagonals(i, b);
                    }
                }
            }

            Console.WriteLine(hits);
        }

        static bool IsInside(int y, int x)
        {
            return y >= 0 && y < table.Count && x >= 0 && x < rowLength;
        }

        static int CheckHorizontaly(int y, int x)
        {
            int right = 1;
            int left = 1;

            for (int i = 1; i < searchString.Length; i++)
            {
                if (IsInside(y, x + i))
                {
                    if (table[y][x + i] != searchString[i])
                    {
                        right = 0;
                    }
                }
                else
                {
                    right = 0;
                }

                if (IsInside(y, x - i))
                {
                    if (table[y][x - i] != searchString[i])
                    {
                        left = 0;
                    }
                }
                else
                {
                    left = 0;
                }
            }

            return left + right;
        }

        static int CheckVertically(int y, int x)
        {
            int down = 1;
            int up = 1;

            for (int i = 1; i < searchString.Length; i++)
            {
                if (IsInside(y + i, x))
                {
                    if (table[y + i][x] != searchString[i])
                    {
                        down = 0;
                    }
                }
                else
                {
                    down = 0;
                }

                if (IsInside(y - i, x))
                {
                    if (table[y - i][x] != searchString[i])
                    {
                        up = 0;
                    }
                }
                else
                {
                    up = 0;
                }
            }

            return up + down;
        }

        static int CheckDiagonals(int y, int x)
        {
            int ULeft = 1;
            int URight = 1;
            int DLeft = 1;
            int DRight = 1;

            for (int i = 1; i < searchString.Length; i++)
            {
                if (IsInside(y - i, x - i))
                {
                    if (table[y - i][x - 1] != searchString[i])
                    {
                        ULeft = 0;
                    }
                }
                else
                {
                    ULeft = 0;
                }

                if (IsInside(y - i, x + i))
                {
                    if (table[y - i][x + i] != searchString[i])
                    {
                        URight = 0;
                    }
                }
                else
                {
                    URight = 0;
                }

                if (IsInside(y + i, x - i))
                {
                    if (table[y + i][x - i] != searchString[i])
                    {
                        DLeft = 0;
                    }
                }
                else
                {
                    DLeft = 0;
                }

                if (IsInside(y + i, x + i))
                {
                    if (table[y + i][x + i] != searchString[i])
                    {
                        DRight = 0;
                    }
                }
                else
                {
                    DRight = 0;
                }
            }

            return ULeft + URight + DLeft + DRight;
        }
    }
}
