using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Program
    {


        static void Main(string[] args)
        {

            List<int> myList = new List<int>();
            myList.AddRange(new int[] { 78, 100, 92, 88, 65, 43, 70, 81, 55, 95 });


            List<string> grades = myList.ConvertAll(
                new Converter<int, string>(IntToGrade)
                );


            foreach (string grade in grades)
            {
                Console.WriteLine(grade);
            }

            //delegate version
            Console.WriteLine("--------------------------------------");
            List<int> resultB = myList.FindAll(
                delegate(int g)
                {
                    return ((g >= 80 && g < 90));
                }
            );

            foreach (int grade in resultB)
            {
                Console.WriteLine(grade);
            }

            //lambda version
            Console.WriteLine("--------------------------------------");

            List<int> resultA = myList.FindAll(x => (x >= 90 && x <= 100));

            foreach (int grade in resultA)
            {
                Console.WriteLine(grade);
            }


            Console.ReadLine();


        }

        private static string IntToGrade(int input)
        {
            if (input > 90) return "A";
            if (input > 80) return "B";
            if (input > 70) return "C";
            return "F";
        }
    }
}
