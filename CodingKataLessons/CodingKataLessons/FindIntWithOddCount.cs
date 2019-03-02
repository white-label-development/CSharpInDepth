using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace CodingKataLessons
{

    /*
     * Given an array, find the int that appears an odd number of times.

        There will always be only one integer that appears an odd number of times.
     */


    //mine (I knew I was doing it the noob way, but failed to imagine the clever people's below)
    public static class FindIntWithOddCount
    {
        public static int find_it(int[] seq)
        {
            //how many times does each number occur?
            var numberCount = new Dictionary<int, int>();
            foreach (var number in seq)
            {
                if (!numberCount.ContainsKey(number)) numberCount.Add(number, 0);
                numberCount[number] = numberCount[number] + 1;
            }

            foreach (var key in numberCount.Keys)
            {
                if (numberCount[key] % 2 > 0) return key;
            }

            return -1;
        }

        //clever peoples

        public static int find_it_1(int[] seq)
        {
            return seq.GroupBy(x => x).Single(g => g.Count() % 2 == 1).Key;
        }

        public static int find_it2(int[] seq)
        {
            return seq.ToList()
                .GroupBy(x => x) //Group by each element in the array
                .Where(x => (x.Count() % 2) != 0) //Find grouped odd numbers
                .Select(x => x.First())
                .FirstOrDefault(); //since array will only contain 1 odd number, get first one
        }


        public static int find_it3(int[] seq)
        {
            return seq.Aggregate(0, (a, b) => a ^ b);
        }

        //https://stackoverflow.com/questions/7105505/linq-aggregate-algorithm-explained
        //nt note:The ^ character, or 'caret' character is a bitwise XOR operator.
        //i understand the use of the Aggregate function - i must use it more, but XOR is doing my head in.

    }



    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void Tests()
        {
            Assert.AreEqual(5, FindIntWithOddCount.find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
        }
    }
}
