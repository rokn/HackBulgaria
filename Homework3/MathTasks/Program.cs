using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> v1 = new List<int>() { 3,5,3,2,1,0 },
            //          v2 = new List<int>() { 0,1,1,3,1,1 };
            //Console.WriteLine(MaxScalarProduct(v1, v2));


            //List<int> spanNumbs = new List<int>() { 1, 4,1,1,1,1,1,1,1,1,1,1,1,1, 2, 1, 4, 4, 4 };
            //Console.WriteLine(MaxSpan(spanNumbs));


            //List<int> birtdays = new List<int>() { 5, 10, 6, 7, 3, 4, 5, 11, 21, 300, 15 };
            List<KeyValuePair<int, int>> ranges = new List<KeyValuePair<int, int>>();
            //ranges.Add(new KeyValuePair<int, int>(4, 9));
            //ranges.Add(new KeyValuePair<int, int>(6, 7));
            //ranges.Add(new KeyValuePair<int, int>(200, 225));
            //ranges.Add(new KeyValuePair<int, int>(300, 365));
            KeyValuePair<int,int> kvp = new KeyValuePair<int, int>()

            //List<int> result = BirthdayRanges(birtdays, ranges);

            //foreach (var day in result)
            //{
            //    Console.WriteLine(day);
            //}


            //int[,] matrix = new int[3, 4] { {1,2,3,4 }, { 5,6,7,8 }, { 9,10,11,12 } };
            //Console.WriteLine(MatrixBombing(matrix));


            List<int> transversal = new List<int> { 1, 2,4 };
            List<List<int>> family = new List<List<int>>() { new List<int>() { 1,5 },
                                                             new List<int>() { 2,3 },
                                                             new List<int>() { 4,7 } };

            Console.WriteLine(IsTransversal(transversal,family));
        }

        static int MaxScalarProduct(List<int> v1, List<int> v2)
        {
            if (v1.Count != v2.Count)
            {
                throw new IndexOutOfRangeException("Vectors must be of same length to calculate scalar product");
            }

            v1.Sort();
            v2.Sort();
            return CalculateScalar(v1, v2);
        }

        static int CalculateScalar(List<int> v1, List<int> v2)
        {
            int scalar = 0;

            for (int i = 0; i < v1.Count; i++)
            {
                scalar += v1[i] * v2[i];
            }

            return scalar;
        }


        struct Values
        {
            public int Value;
            public bool Checked;
            public Values(int value, bool check)
            {
                Value = value;
                Checked = check; 
            }
            public void SetChecked()
            {
                Checked = true;
            }
        }
        static int MaxSpan(List<int> numbers)
        {
            List<Values> values = new List<Values>();
            numbers.ForEach(numb => values.Add(new Values(numb, false)));
            int maxSpan = 0;
            int currSpan = 1;

            for (int i = 0; i < values.Count; i++)
            {
                if(!values[i].Checked)
                {
                    for (int b = i; b < values.Count; b++)
                    {
                        if(values[i].Value == values[b].Value)
                        {
                            values[b].SetChecked();
                            currSpan = (b - i) + 1;
                        }
                    }

                    if(currSpan > maxSpan)
                    {
                        maxSpan = currSpan;
                    }
                    currSpan = 1;
                }
            }

            return maxSpan;
        }
        static List<int> BirthdayRanges(List<int> birthdays, List<KeyValuePair<int, int>> ranges)
        {
            List<int> result = new List<int>();
            List<int> sortedBirthdays = new List<int>(birthdays);
            sortedBirthdays.Sort();

            foreach (var kvp in ranges)
            {
                int start = sortedBirthdays.FindIndex(day => day >= kvp.Key && day <= kvp.Value);
                int end = sortedBirthdays.FindLastIndex(day => day >= kvp.Key && day <= kvp.Value);

                if(start < 0)
                {
                    result.Add(0);
                    continue;
                }

                result.Add((end - start) + 1);
            }

            return result;
        }

        static int MatrixBombing(int[,] m)
        {
            int maxDamage = 0;
            int currDamage = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int b = 0; b < m.GetLength(1); b++)
                {
                    currDamage = CalculateDamage(i, b, m);
                    if(currDamage > maxDamage)
                    {
                        maxDamage = currDamage;
                    }
                }
            }

            return maxDamage;
        }

        private static int CalculateDamage(int i, int b, int[,] m)
        {
            int damage = 0;

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if(!(y == 0 && x==y)) // If it's not the middle cell([i,b])
                    {
                        if(IsInside(i+x, b+y, m))
                        {
                            if(m[i+x, b+y] > m[i, b])
                            {
                                damage += m[i, b];
                            }
                            else
                            {
                                damage += m[i + x, b + y];
                            }
                        }
                    }
                }
            }

            return damage;
        }

        static bool IsInside(int x, int y, int[,] array)
        {
            return x >= 0 && x < array.GetLength(0) && y >= 0 && y < array.GetLength(1);
        }

        static bool IsTransversal(List<int> transversal, List<List<int>> family)
        {

            List<bool> isTransversalList = new List<bool>();

            for (int i = 0; i < family.Count; i++)
            {
                isTransversalList.Add(false);
            }

            for (int i = 0; i < transversal.Count; i++)
            {
                for (int b = 0; b < family.Count; b++)
                {
                    if (!isTransversalList[b])
                    {
                        if (family[b].Contains(transversal[i]))
                        {
                            isTransversalList[b] = true;
                        }
                    }
                }
            }

            for (int i = 0; i < isTransversalList.Count; i++)
            {
                if (!isTransversalList[i])
                    return false;
            }

            return true;
        }
    }
}
