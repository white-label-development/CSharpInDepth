using System;

namespace Module6Assignment
{
    class Program
    {
        //Q: What other objects could benefit from inheritance in this code?
        //A: my other objects don't share enough properties yet - but potentially the Program, Degree, Course classes might share some comment features,
        //such as EstablishmentName, RevisionNumber etc.. and these could be encapsulated in a base class 'Establishment' 

        //Q: Can you think of a different hierarchy for the Person, Teacher, and Student?  What is it?
        //A: Teacher and Student could implement IPerson: Compositions instead of inheritance
        //Or: Teacher and Student could be base classes and Person the sub class (would be strange choice but it's possible)

        public UProgram UProgram { get; set; }
        
        static void Main(string[] args)
        {
           
            //Run the same code in Program.cs from Module 5 
            //to create instances of your classes so that you can setup a single course that is part of a program and a degree path.   
            //Be sure to include at least one Teacher and an array of Students.
            
            var mod6 = new Program();
            mod6.SetupUProgramLikeAssignmentFive(); //Note: pushed this to an instance method to make code clearer.

            //Ensure the Console.WriteLine statements you included in Homework 5, still output the correct information.
            Console.WriteLine(mod6.UProgram.UProgramInfo);


            //hold the page.
            Console.WriteLine("Press return to continue...");
            Console.ReadLine();
        }

        public  void SetupUProgramLikeAssignmentFive()
        {
            //except we set properties on the base class and subclass
            var student1 = new Student { FirstName = "A", LastName = "Student1", StudentId = 1 };
            var student2 = new Student { FirstName = "B", LastName = "Student2", StudentId = 2 };
            var student3 = new Student { FirstName = "C", LastName = "Student3", StudentId = 3 };

            var programmingCourse = new Course { CourseName = "Programming with C#" };

            Student[] students = { student1, student2, student3 };
            programmingCourse.Students = students;

            //set properties on the base class and subclass
            var teacher1 = new Teacher { FirstName = "T", LastName = "Cher", TeacherId = 1 };
            programmingCourse.Teachers = new[] { teacher1 };

            var degree = new Degree { DegreeName = "Science", DegreeType = "Bachelor", Course = programmingCourse };

            UProgram = new UProgram { Degree = degree, ProgramName = "Information Technology" }; 
        }
    }

    //Create a Person base class with common attributes for a person
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    //Make your Student and Teacher classes inherit from the Person base class
    //Modify your Student and Teacher classes so that they inherit the common attributes from Person

    //Modify your Student and Teacher classes so they include characteristics specific to their type.  
    //For example, a Teacher object might have a GradeTest() method where a student might have a TakeTest() method.
    public class Student: Person
    {
        public static int EnrolledStudents { get; set; }

        public int StudentId { get; set; }       
        //etc.

        public Student()
        {
            EnrolledStudents++;
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
