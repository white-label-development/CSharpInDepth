using System;

namespace Module3Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            GetStudentInfo();
            GetTeacherInfo();
            GetCourseInfo();

            //throws
            ValidateStudentsBirthday();
        }


        #region " Get"
        static void GetStudentInfo()
        {
            Console.WriteLine("Enter the student's first name: ");
            string firstName = Console.ReadLine();
            
            Console.WriteLine("Enter the student's last name");
            string lastName = Console.ReadLine();

            // 1. complete the method for getting student data.
            Console.WriteLine("Enter the student's final bit of data");
            string otherData = Console.ReadLine();

            //4: show you understand how to use methods.
            PrintStudentDetails(firstName, lastName, otherData);
        }

        //2: Create a method to get information for a teacher, a course, and program, and a degree
        static void GetTeacherInfo()
        {
            Console.WriteLine("Enter the teachers first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the teachers last name");
            string lastName = Console.ReadLine();
            
            Console.WriteLine("Enter the teachers final bit of data");
            string otherData = Console.ReadLine();

            //4: show you understand how to use methods.
            PrintTeacherDetails(firstName, lastName, otherData);
        }

        //2: ...
        static void GetCourseInfo()
        {
            Console.WriteLine("Enter the course name: ");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter the courses final bit of data");
            string otherData = Console.ReadLine();

            //4: show you understand how to use methods.
            PrintCourseDetails(name, otherData);
        }

        //let's face it: GetProgramData and GetDegreeData are the same. Pretend I did them.

        #endregion

        #region " Print"
        //3: Create methods to print the information to the screen for each object 
        static void PrintStudentDetails(string first, string last, string otherData)
        {
            Console.WriteLine("{0} {1} has this info: {2}", first, last, otherData);
        }
        static void PrintTeacherDetails(string first, string last, string otherData)
        {
            Console.WriteLine("{0} {1} has this info: {2}", first, last, otherData);
        }
        static void PrintCourseDetails(string name, string otherData)
        {
            Console.WriteLine("{0} has this info: {1}", name, otherData);
        }
        #endregion

        //Create a new method for validating a student's birthday.  You won't write any validation code in this method, but you will throw the NotImplementedException in this method
        static void ValidateStudentsBirthday()
        {
            throw new NotImplementedException("ValidateStudentsBirthday has not been implemented yet.");
        }
    }
}
