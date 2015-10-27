using System;

namespace Points
{
    public class Program
    {
        static void Main(string[] args)
        {
            int reverser = 1;
            int currX;
            int currY;
            bool correct;            
            string startingPoint;

            do
            {                
                correct = true;
                startingPoint = Console.ReadLine();

                // Start point was shown in the example to be in the format "Starting point: (x, y)" so I'm reformating to get the coordinates
                //removing "Starting point: ("
                startingPoint = startingPoint.Substring(17);
                //removing last ')'
                startingPoint = startingPoint.Substring(0, startingPoint.Length - 1);
                //removing space
                startingPoint = startingPoint.Replace(" ", "");
                //spliting the numbers            
                string[] splitted = startingPoint.Split(new Char[] { ',' });

                if (!int.TryParse(splitted[0], out currX))
                {
                    correct = false;
                }
                if (!int.TryParse(splitted[1], out currY))
                {
                    correct = false;
                }                
            } while (!correct);

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                switch(input[i])
                {
                    case '~':
                        reverser *= -1;
                        break;
                    case '>':
                        currX += reverser;
                        break;
                    case '<':
                        currX -= reverser;
                        break;
                    case 'v':
                        currY += reverser;
                        break;
                    case '^':
                        currY -= reverser;
                        break;
                }
            }

            Console.WriteLine("({0}, {1})", currX, currY);
        }
    }
}
