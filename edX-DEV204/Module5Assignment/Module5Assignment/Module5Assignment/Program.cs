using System;

namespace Module5Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var student1 = new Student {FirstName = "A", LastName = "Student1"};
            var student2 = new Student { FirstName = "B", LastName = "Student2" };
            var student3 = new Student { FirstName = "C", LastName = "Student3" };

            var programmingCourse = new Course {CourseName = "Programming with C#"};

            Student[] students = {student1, student2, student3};
            programmingCourse.Students = students;

            var teacher1 = new Teacher { TeacherFirstName = "T", TeacherLastName = "Cher" };
            programmingCourse.Teachers = new[] {teacher1};

            var degree = new Degree { DegreeName = "Science", DegreeType = "Bachelor", Course = programmingCourse };

            var uProgram = new UProgram { Degree = degree, ProgramName = "Information Technology" };

            string programName = uProgram.ProgramName;
            string degreeType = uProgram.Degree.DegreeType;
            string degreeName = uProgram.Degree.DegreeName;
            string courseName = uProgram.Degree.Course.CourseName;
            int studentCount = Student.EnrolledStudents;

            Console.WriteLine(string.Format("The {0} program contains the {1} of {2} degree", programName, degreeType, degreeName));
            Console.WriteLine(string.Format("The {0} of {1} degree contains the course {2}", degreeType, degreeName, courseName));
            Console.WriteLine(string.Format("The {0} contains {1} student(s)", courseName, studentCount));

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }         
    }


    public class Student
    {
        public static int EnrolledStudents { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //etc.

        public Student()
        {
            EnrolledStudents++;
        }
    }

    public class Teacher
    {
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
    }

    public class UProgram 
    {
        public Degree Degree { get; set; }
        public string ProgramName { get; set; }
    }

    public class Degree
    {
        public Course Course { get; set; }
        public string DegreeName { get; set; }
        public string DegreeType { get; set; }
    }

    public class Course
    {
        public Student[] Students { get; set; }
        public Teacher[] Teachers { get; set; }

        public string CourseName { get; set; }

        public Course()
        {
            Students = new Student[3];
            Teachers = new Teacher[3];
        }       
    }
}
