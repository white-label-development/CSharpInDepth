using System;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main_mine(string[] args)
        {

            const int xAxisLength = 8;
            const int yAxisLength = 8;
            const char blackSquare = 'X';
            const char whiteSquare = 'O';           
            

            for (int yCounter = 0; yCounter < yAxisLength; yCounter++)
            {
                bool showBlackSquare = (yCounter % 2) == 0 ;
                for (int xCounter = 0; xCounter < xAxisLength; xCounter++)
                {
                    if (showBlackSquare)
                    {
                        Console.Write(blackSquare);
                        showBlackSquare = false;
                    }
                    else
                    {
                        Console.Write(whiteSquare);
                        showBlackSquare = true;
                    }
                }
                Console.WriteLine();
            }
            
            Console.ReadLine();
        }


        static void Main_Review1(string[] args)
        {
            int m, n;

            for (m = 1; m <= 8; m++)
            {
                for (n = 1; n <= 4; n++)
                {
                    if (m % 2 == 0) Console.Write("OX");
                    else Console.Write("XO");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static void Main_Review2(string[] args)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i%2 != 0 && j%2 != 0) Console.Write("X");
                    if (i%2 != 0 && j%2 == 0) Console.Write("O");
                    if (i%2 == 0 && j%2 != 0) Console.Write("O");
                    if (i%2 == 0 && j%2 == 0) Console.Write("X");
                }
                Console.WriteLine();
               
            }
            Console.ReadLine();
        }


    }
}
