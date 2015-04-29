using System;
using System.Collections;
using System.Globalization;

namespace Module7Assignment
{
    class Program
    {

        //challenge: Sort the ArrayList of students.
        public class StudentIdComparer : IComparer
        {
            Comparer _comparer = new Comparer(CultureInfo.CurrentCulture);
            public int Compare(object x, object y)
            {
                Student a = (Student)x;
                Student b = (Student)y;
                return _comparer.Compare(Convert.ToInt32(a.StudentId), Convert.ToInt32(b.StudentId));
            }
        }

        public UProgram UProgram { get; set; }
        

        static void Main(string[] args)
        {           
            var mod7 = new Program();
            mod7.SetupUProgramLikeAssignmentFive(); //Note: pushed this to an instance method to make code clearer.

            mod7.UProgram.Degree.Course.ListStudents();

            var unsortedStudents = mod7.UProgram.Degree.Course.Students;
            unsortedStudents.Sort(new StudentIdComparer());
            Console.WriteLine("");
            foreach (Student student in unsortedStudents)
            {
                Console.WriteLine("sorted Students: StudentId={0}", student.StudentId);
            }


            //challenge: To simulate changing a grade for a student, remove the last entered grade and replace it with a new one.
            Console.WriteLine("");
            var studentWithGrades = (Student)mod7.UProgram.Degree.Course.Students[0];
            Console.WriteLine("Popped grade={0}", studentWithGrades.Grades.Pop());
            studentWithGrades.Grades.Push(23);
            Console.WriteLine("Pushed grade={0}", studentWithGrades.Grades.Peek());

            //Bonus challenge:  Ensure you have added at least 5 grades to the stack.  Replace the third grade in the stack without losing the two grades above it.
           

            //before
            Console.WriteLine("");
            Console.WriteLine("stack before change");
            foreach (var grade in studentWithGrades.Grades)
            {
                Console.WriteLine((int)grade);
            }

            var stackItem1 = studentWithGrades.Grades.Pop();
            var stackItem2 = studentWithGrades.Grades.Pop();
            studentWithGrades.Grades.Pop(); // 3 will be replaced
            var stackItem4 = studentWithGrades.Grades.Pop();
            var stackItem5 = studentWithGrades.Grades.Pop();

            //stack is not empty - we can refill it but with a different third item

            studentWithGrades.Grades.Push(stackItem5);
            studentWithGrades.Grades.Push(stackItem4);
            studentWithGrades.Grades.Push(99); //new third grade
            studentWithGrades.Grades.Push(stackItem2);
            studentWithGrades.Grades.Push(stackItem1);

            Console.WriteLine("");
            Console.WriteLine("stack after change");
            foreach (var grade in studentWithGrades.Grades)
            {
                Console.WriteLine((int)grade);
            }
            
            //hold the page.
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press return to continue...");
            Console.ReadLine();
        }


        //Modify your code to use the ArrayList collection as the replacement to the array.  In other words, when you add a Student to the Course object, you will add it to the ArrayList and not an array.
        public void SetupUProgramLikeAssignmentFive()
        {            
            var programmingCourse = new Course { CourseName = "Programming with C#" };

            //Create 3 student objects.
            //Add the three Student objects to the Students ArrayList inside the Course object
            programmingCourse.Students.Add(new Student { FirstName = "A", LastName = "Student1", StudentId = 1 });           
            programmingCourse.Students.Add(new Student { FirstName = "C", LastName = "Student3", StudentId = 3 });
            programmingCourse.Students.Add(new Student { FirstName = "B", LastName = "Student2", StudentId = 2 });

            //Add 5 grades to the the Stack in the each Student object. 
            //(this does not have to be inside the constructor because you may not have grades for a student when you create a new student.)
            foreach (Student student in programmingCourse.Students)
            {
                student.Grades = CreateFiveRandomGrades();
            }

           
            //Stuff from Module 5 and 6..
            //set properties on the base class and subclass
            var teacher1 = new Teacher { FirstName = "T", LastName = "Cher", TeacherId = 1 };
            programmingCourse.Teachers = new[] { teacher1 };

            var degree = new Degree { DegreeName = "Science", DegreeType = "Bachelor", Course = programmingCourse };

            UProgram = new UProgram { Degree = degree, ProgramName = "Information Technology" };
        }

        public Stack CreateFiveRandomGrades()
        {
            var stack = new Stack();
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

    
    public class Student : Person
    {
        public static int EnrolledStudents { get; set; }

        //Create a Stack object inside the Student object, called Grades, to store test scores.
        public Stack Grades { get; set; }

        public int StudentId { get; set; }
        //etc.

        public Student()
        {
            EnrolledStudents++;
            Grades = new Stack();
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
        //public Student[] Students { get; set; } //Delete the Student array in your Course object that you created in Module 5.
        
        //Create an ArrayList to replace the array and to hold students, inside the Course object.
        public ArrayList Students { get; set; }
        
        public Teacher[] Teachers { get; set; }

        public string CourseName { get; set; }

        public Course()
        {
            Students = new ArrayList();
            Teachers = new Teacher[3];
        }

        //Create a method inside the Course object called ListStudents() that contains the foreach loop.
        //Using a foreach loop, iterate over the Students in the ArrayList and output their first and last names to the console window.
        public void ListStudents()
        {
            foreach (var obj in Students)
            {
                var student = (Student)obj;
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            } 
        }

        
           
            
    }
}
