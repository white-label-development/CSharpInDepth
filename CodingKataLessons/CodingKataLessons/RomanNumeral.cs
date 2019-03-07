using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingKataLessons
{
    class RomanConvert
    {
        /*
         *Create a function taking a positive integer as its parameter and returning a string containing the Roman Numeral representation of that integer.

        Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero. In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.

        Example:

        RomanConvert.Solution(1000) -- should return "M"
         */


        //my solution (ran out of time and really interested to see how it should be done)
        public static string Solution(int n)
        {
            string result = null;
            var map = new Dictionary<int, string>
            {
                {1, "I"},
                {5, "V"},
                {10, "X"},
                {50, "L"},
                {100, "C"},
                {500, "D"},
                {1000, "M"}
            };


            //must be a max of MMM
            int targetValue = n;
            int counter = 0; //debug
            int previousVal = 0;
            while (targetValue > 0)
            {
                // map.OrderByDescending(x => x.Key)
                foreach (var keyValuePair in map.OrderByDescending(x => x.Key))
                {                  
                    int currentVal = keyValuePair.Key;

                    if(targetValue < currentVal) continue;

                    //maybe take 10% of key, if it's the same as target value we do CM (900) other wise we use 0-3 repeats DCCC


                    result += keyValuePair.Value;
                    targetValue -= currentVal;
                    previousVal = currentVal;
                }
                


                counter++;
                if(counter > 10) break; //debug helper
            }


            return result;
        }


        //and the clever people did:
        public static string Solution_1(int n)
        {
            var result = new string('I', n);
            return result
                .Replace(new string('I', 1000), "M")
                .Replace(new string('I', 900), "CM")
                .Replace(new string('I', 500), "D")
                .Replace(new string('I', 400), "CD")
                .Replace(new string('I', 100), "C")
                .Replace(new string('I', 90), "XC")
                .Replace(new string('I', 50), "L")
                .Replace(new string('I', 40), "XL")
                .Replace(new string('I', 10), "X")
                .Replace(new string('I', 9), "IX")
                .Replace(new string('I', 5), "V")
                .Replace(new string('I', 4), "IV");
        }

        public static string Solution_2(int n)
        {
            return new string(new Dictionary<int, string>
            {
                {1000, "M"},
                {900, "CM"},
                {500, "D"},
                {400, "CD"},
                {100, "C"},
                {90, "XC"},
                {50, "L"},
                {40, "XL"},
                {10, "X"},
                {9, "IX"},
                {5, "V"},
                {4, "IV"},
                {1, "I"}
            }.Aggregate(new string('I', n), (m, _) => m.Replace(new string('I', _.Key), _.Value)).ToCharArray());
        }

        //close to what I was doing, they just added the CM, CD, XC, XL, IX, IV entries 
        public static string Solution_3(int n)
        {
            var romeDict = new Dictionary<int, string>()
            {
                [1000] = "M",
                [900] = "CM",
                [500] = "D",
                [400] = "CD",
                [100] = "C",
                [90] = "XC",
                [50] = "L",
                [40] = "XL",
                [10] = "X",
                [9] = "IX",
                [5] = "V",
                [4] = "IV",
                [1] = "I"
            };

            var number = new StringBuilder();
            foreach (var romeNum in romeDict)
            {
                while (romeNum.Key <= n)
                {
                    number.Append(romeNum.Value);
                    n -= romeNum.Key;
                }
            }

            return number.ToString();
        }
    }


    [TestFixture]
    public class RomanConvertTests
    {
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(1954, "MCMLIV")]
        [TestCase(1990, "MCMXC")]
        [TestCase(2008, "MMVIII")]
        [TestCase(2014, "MMXIV")]
        public void Test(int value, string expected)
        {
            Assert.AreEqual(expected, RomanConvert.Solution(value));
        }
    }
}
