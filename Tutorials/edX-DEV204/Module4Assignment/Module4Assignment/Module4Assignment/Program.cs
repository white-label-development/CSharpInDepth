using System;

namespace Module4Assignment
{
    class Program
    {


        static void Main(string[] args)
        {
            //Create an array to hold 5 student structs.
            Student[] students = new Student[5] {
                new Student {FirstName = "a", LastName = "b"}, 
                new Student {FirstName = "c", LastName = "d" }, 
                new Student {FirstName = "e", LastName = "f" }, 
                new Student {FirstName = "g", LastName = "h" }, 
                new Student {FirstName = "i", LastName = "j" }};

            //Assign values to the fields in at least one of the student structs in the array
            students[0].FirstName = "fn";
            students[0].LastName = "ln";


            //Using a series of Console.WriteLine() statements, output the values for the student struct that you assigned in the previous step
            Console.WriteLine(string.Format("{0} {1}", students[0].FirstName, students[0].LastName));
            Console.WriteLine(string.Format("{0} {1}", students[1].FirstName, students[1].LastName));
            Console.WriteLine(string.Format("{0} {1}", students[2].FirstName, students[2].LastName));
            Console.WriteLine(string.Format("{0} {1}", students[3].FirstName, students[3].LastName));
            Console.WriteLine(string.Format("{0} {1}", students[4].FirstName, students[4].LastName));

            Console.ReadLine();
        }


        struct Student
        {
            public Student(string fn, string ln)
                : this()
            {
                FirstName = fn;
                LastName = ln;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        struct Teacher
        {
            public Teacher(string fn, string ln)
                : this()
            {
                TeacherFirstName = fn;
                TeacherLastName = ln;
            }
            public string TeacherFirstName { get; set; }
            public string TeacherLastName { get; set; }
        }

        struct UProgram
        {
            public UProgram(string name)
                : this()
            {
                ProgramName = name;
            }
            public string ProgramName { get; set; }
        }


        struct Course
        {
            public Course(string name)
                : this()
            {
                CourseName = name;
            }
            public string CourseName { get; set; }
        }
    }
}
