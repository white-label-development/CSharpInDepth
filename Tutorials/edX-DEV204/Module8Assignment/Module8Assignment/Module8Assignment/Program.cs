using System;
using System.Collections.Generic;

namespace Module8Assignment
{
    //brought over from module 7
    class Program
    {       
        public UProgram UProgram { get; set; }

        static void Main(string[] args)
        {
            var mod8 = new Program();
            mod8.SetupUProgramLikeAssignmentFive(); //Note: pushed this to an instance method to make code clearer.

            
            //Using a foreach loop, iterate over the Students in the List<T> and output their first and last names to the console window. 
            //(For this exercise, casting is no longer required.  Also, place each student name on its own line)            
            //Create a method inside the Course object called ListStudents() that contains the foreach loop.
            //Call the ListStudents() method from Main().
            mod8.UProgram.Degree.Course.ListStudents();


            //Challenge: To simulate changing a grade for a student, remove the last entered grade and replace it with a new one.
            Console.WriteLine("");
            var student = mod8.UProgram.Degree.Course.Students[1];
            Console.WriteLine("students last entered grade was {0}",student.Grades.Peek() );
            int oldGrade =student.Grades.Pop();
            student.Grades.Push(23);
            Console.WriteLine("students last entered grade of {0} has been replaced with {1}", oldGrade, student.Grades.Peek());

            //Challenge: Research the Generic collections on http://msdn.microsoft.com and find a Generic collection to store grades in a sorted order. 
            SortedSet<int> gradeSorter = new SortedSet<int>( ); //default comparer will do
            gradeSorter.Add(56);
            gradeSorter.Add(2);
            gradeSorter.Add(42);

            Console.WriteLine("");
            foreach (var item in gradeSorter)
            {
                Console.WriteLine(item);
            }
            //returns sorted items: 2, 42, 56.



            //hold the page.
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press return to continue...");
            Console.ReadLine();
        }


        public void SetupUProgramLikeAssignmentFive()
        {
            var programmingCourse = new Course { CourseName = "Programming with C#" };

            //Create 3 student objects.           
            //add the three Student objects to the List<T>  inside the Course object.
            programmingCourse.Students.Add(new Student { FirstName = "A", LastName = "Student1", StudentId = 1 });
            programmingCourse.Students.Add(new Student { FirstName = "C", LastName = "Student3", StudentId = 3 });
            programmingCourse.Students.Add(new Student { FirstName = "B", LastName = "Student2", StudentId = 2 });

            //Add 5 grades to the the Stack in the each Student object. 
            //(this does not have to be inside the constructor because you may not have grades for a student when you create a new student.)
            foreach (Student student in programmingCourse.Students)
            {
                student.Grades = CreateFiveRandomGrades();
            }


           //other setup stuff
            var teacher1 = new Teacher { FirstName = "T", LastName = "Cher", TeacherId = 1 };
            programmingCourse.Teachers = new[] { teacher1 };

            var degree = new Degree { DegreeName = "Science", DegreeType = "Bachelor", Course = programmingCourse };

            UProgram = new UProgram { Degree = degree, ProgramName = "Information Technology" };
        }

        public Stack<int> CreateFiveRandomGrades()
        {
            var stack = new Stack<int>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int randomGrade = random.Next(0, 100);
                stack.Push(randomGrade);
            }
            return stack;
        }
    }



    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    //Create a Stack<T> object, of the proper data type, inside the Student object, called Grades, to store test scores.
    public class Student : Person
    {
        public static int EnrolledStudents { get; set; }

        //Create a Stack object inside the Student object, called Grades, to store test scores.
        public Stack<int> Grades { get; set; }

        public int StudentId { get; set; }
        //etc.

        public Student()
        {
            EnrolledStudents++;
            Grades = new Stack<int>();
        }

        public void TakeTest()
        {
            throw new NotImplementedException();
        }
    }

    public class Teacher : Person
    {
        public int TeacherId { get; set; }

        public void GradeTest()
        {
            throw new NotImplementedException();
        }
    }

    public class UProgram
    {
        public Degree Degree { get; set; }
        public string ProgramName { get; set; }

        public string UProgramInfo
        {
            get
            {
                string programName = ProgramName;
                string degreeType = Degree.DegreeType;
                string degreeName = Degree.DegreeName;
                string courseName = Degree.Course.CourseName;
                int studentCount = Student.EnrolledStudents;

                string info = "";
                info += (string.Format("The {0} program contains the {1} of {2} degree" + Environment.NewLine, programName, degreeType, degreeName));
                info += (string.Format("The {0} of {1} degree contains the course {2}" + Environment.NewLine, degreeType, degreeName, courseName));
                info += (string.Format("The {0} contains {1} student(s)" + Environment.NewLine, courseName, studentCount));
                return info;


            }
        }
    }

    public class Degree
    {
        public Course Course { get; set; }
        public string DegreeName { get; set; }
        public string DegreeType { get; set; }
    }


    
    public class Course
    {

        //Create a List<T>, of the proper data type, to replace the ArrayList and to hold students, inside the Course object.
        public List<Student> Students { get; set; }

        public Teacher[] Teachers { get; set; }

        public string CourseName { get; set; }

        public Course()
        {
            Students = new List<Student>();
            Teachers = new Teacher[3];
        }

        public void ListStudents()
        {
            foreach (var student in Students)
            {                
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }




    }
}
