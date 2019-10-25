using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingKataLessons
{
    // https://www.codewars.com/kata/557f6437bf8dcdd135000010/train/csharp

    /*
    In mathematics, the factorial of integer n is written as n!. It is equal to the product of n and every integer preceding it. For example: 5! = 1 x 2 x 3 x 4 x 5 = 120

    Your mission is simple: write a function that takes an integer n and returns the value of n!.

    You are guaranteed an integer argument. For any values outside the non-negative range, return null, nil or None (return an empty string "" in C and C++). For non-negative numbers a full length number is expected for example, return 25! = "15511210043330985984000000" as a string. */

    public class LargeFactorials
    {
        public static string Factorial(int n)
        {
            return "";
        }
    }


    [TestFixture]
    public class LargeFactorialsTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("1", LargeFactorials.Factorial(1));
            Assert.AreEqual("120", LargeFactorials.Factorial(5));
            Assert.AreEqual("362880", LargeFactorials.Factorial(9));
            Assert.AreEqual("1307674368000", LargeFactorials.Factorial(15));
        }
    }

}

