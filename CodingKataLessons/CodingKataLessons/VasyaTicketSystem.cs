using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace CodingKataLessons
{
    static class VasyaTicketSystem
    {
        /*
         * The new "Avengers" movie has just been released! There are a lot of people at the cinema box office standing in a huge line. Each of them has a single 100, 50 or 25 dollars bill. An "Avengers" ticket costs 25 dollars.

        Vasya is currently working as a clerk. He wants to sell a ticket to every single person in this line.

        Can Vasya sell a ticket to each person and give the change if he initially has no money and sells the tickets strictly in the order people follow in the line?

        Return YES, if Vasya can sell a ticket to each person and give the change with the bills he has at hand at that moment. Otherwise return NO.
         */

        public static string Tickets(int[] peopleInLine)
        {

           //NOTE: I have done this wrong!!!!
           //it's not about have we enough money to provide the change required, but also DO WE HAVE THE CORRECT NOTES TO DO SO

           //Live and learn....

            //dollars: 100, 50 , 25
            var ticketPrice = 25;
            var cashTotal = 0;

            if (peopleInLine.FirstOrDefault() != ticketPrice) return "NO";

            foreach (var ticketRequest in peopleInLine)
            {
                var changeRequired = ticketRequest - ticketPrice;
                if (changeRequired > cashTotal) return "NO";
                cashTotal += (ticketPrice);
            }
          
            return "YES";
        }


        // ... and the clever people did

        //a notes tracker
        public static string Tickets1(int[] peopleInLine)
        {
            int twentyFives = 0, fifties = 0;

            foreach (var bill in peopleInLine)
            {
                switch (bill)
                {
                    case 25:
                        ++twentyFives;
                        break;
                    case 50:
                        --twentyFives;
                        ++fifties;
                        break;
                    case 100:
                        if (fifties == 0)
                        {
                            twentyFives -= 3;
                        }
                        else
                        {
                            --twentyFives;
                            --fifties;
                        }
                        break;
                }

                if (twentyFives < 0 || fifties < 0)
                {
                    return "NO";
                }
            }

            return "YES";
        }

        //but this does not track the notes??? hmn..
        public static string Tickets2(int[] peopleInLine)
        {
            string result = "";
            int sum = 0, given = 0;
            foreach (int i in peopleInLine)
            {
                given = (i - 25);
                sum += 25 - given;
                result = "YES";
                if (sum < given)
                    result = "NO";
            }
            return result;
        }

    }


    
    [TestFixture]
    public class LineTests
    {
        [Test]
        public void Test1()
        {
            int[] peopleInLine = new int[] { 25, 25, 50, 50 };
            Assert.AreEqual("YES", VasyaTicketSystem.Tickets(peopleInLine));
        }

        [Test]
        public void Test2()
        {
            int[] peopleInLine = new int[] { 25, 100 };
            Assert.AreEqual("NO", VasyaTicketSystem.Tickets(peopleInLine));
        }

        //nt: in code wars my code passed these tests but failed the hidden tests, below
        

        [Test]
        public void Test3()
        {
            int[] peopleInLine = new int[] { 25, 25, 25, 25, 25, 25, 25, 25, 25, 25 };
            Assert.AreEqual("YES", VasyaTicketSystem.Tickets(peopleInLine));
        }

        [Test]
        public void Test4()
        {
            int[] peopleInLine = new int[] { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 };
            Assert.AreEqual("NO", VasyaTicketSystem.Tickets(peopleInLine));
        }

        [Test]
        public void Test5()
        {
            int[] peopleInLine = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
            Assert.AreEqual("NO", VasyaTicketSystem.Tickets(peopleInLine));
        }

        [Test]
        public void Test6()
        {
            int[] peopleInLine = new int[] { 25, 25, 25, 25, 50, 100, 50 };
            Assert.AreEqual("YES", VasyaTicketSystem.Tickets(peopleInLine));
        }

        [Test]
        public void Test7()
        {
            int[] peopleInLine = new int[] { 25, 25 };
            Assert.AreEqual("YES", VasyaTicketSystem.Tickets(peopleInLine));
        }

        [Test]
        public void Test8()
        {
            int[] peopleInLine = new int[] { 50, 100, 100 };
            Assert.AreEqual("NO", VasyaTicketSystem.Tickets(peopleInLine));
        }

        [Test]
        public void Test9()
        {
            int[] peopleInLine = new int[] { 25, 25, 25, 25, 25, 25, 25, 50, 50, 50, 100, 100, 100, 100 };
            Assert.AreEqual("NO", VasyaTicketSystem.Tickets(peopleInLine));
        }

        [Test]
        public void Test10()
        {
            int[] peopleInLine = new int[] { 25, 25, 50, 50, 100 };
            Assert.AreEqual("NO", VasyaTicketSystem.Tickets(peopleInLine));
        }
        [Test]
        public void Test11()
        {
            int[] peopleInLine = new int[] { 25, 25, 25, 25, 25, 100, 100 };
            Assert.AreEqual("NO", VasyaTicketSystem.Tickets(peopleInLine));
        }
    }
}
