using System;

namespace Module1Assignment
{
    class Program
    {
        static void Main(string[] args)
        {

            //Student information:
            string firstName = "bob";
            string lastName = "dobbs";
            DateTime birthdate= new DateTime(1973,1,1);
            string addressLine1, addressLine2;
            addressLine1 = "a1";
            addressLine2 = "a2";
            string city = "a city";
            string stateOrProvince = "Timbuktoo";
            string zipOrPostal = "Tim1";
            string country = "Mali";

            

            //Professor information with pertinent fields
            string profFirstName = "E";
            string profLastName = " Vil";
            string profTitle = "Dr.";

            

            //A university degree with pertinent fields such as Bachelor or Master
            string degreeName = "Origami";
            string degreeType = "Bachelor";
            int degreeCreditsRequired;

            //A university program with pertinent fields such as Computer Science or Arts.:
            string programName = "Program 1";
            int programDepartmentHeadId = 23;


            //Information for a course that would be part of your selected degree and program, with pertinent fields
            string courseName = "Beginning Origami";
            int coursePoints = 10;
            string courseDescription =" blah blah blah";

            //use the Console.WriteLine() method to output the values to the console window.
            Console.WriteLine(firstName);
            //note: I'm not writing them all out as that's too boring.

            //challenge:
            //Investigate the .NET Framework documenation around Console.ReadLine() and modify your code 
            //to use this method for accepting input from a user of your application and assign it to the variables you have created.

            Console.WriteLine("Please enter your first name");
            string inputFirstName = Console.ReadLine();
            Console.WriteLine("Thanks " + inputFirstName);

            Console.ReadLine(); //hold the console window so we can read it.

        }
    }
}
