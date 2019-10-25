
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

    You are guaranteed an integer argument. For any values outside the non-negative range, return null, nil or None (return an empty string "" in C and C++). 
    For non-negative numbers a full length number is expected for example, return 25! = "15511210043330985984000000" as a string. */

    public class LargeFactorials
    {
        // can't cope with the extended test case where the result is too big for any allowed datatype
        public static string TooSimpleFactorial(int n)
        {

            decimal factorial = 1;
            for (decimal i = 1; i <= n; i++) { factorial *= i; }
            return factorial > 0 && n > 0 ? factorial.ToString() : null;
        }



        // looked up solution online out of curiosity... I was toying with stashing the value in a string at each 20! but couldn't see how to continue with the calculation.
        // once again my poor maths is an issue.

        // https://www.geeksforgeeks.org/factorial-large-number/

        public static string Factorial(int n)
        {
            int[] res = new int[500];

            // Initialize result 
            res[0] = 1;
            int res_size = 1;

            // Apply simple factorial formula  
            // n! = 1 * 2 * 3 * 4...*n 
            for (int x = 2; x <= n; x++)
                res_size = multiply(x, res, res_size);

            Console.WriteLine("Factorial of " +
                              "given number is ");

            string result = "";

            for (int i = res_size - 1; i >= 0; i--)
            {
                Console.Write(res[i]);
                result += res[i];
            }

            return n > 0 ? result : null;
            
        }

        // This function multiplies x  
        // with the number represented  
        // by res[]. res_size is size  
        // of res[] or number of digits  
        // in the number represented by  
        // res[]. This function uses  
        // simple school mathematics for  
        // multiplication. This function  
        // may value of res_size and  
        // returns the new value of res_size 
        static int multiply(int x, int[] res,
            int res_size)
        {
            int carry = 0; // Initialize carry 

            // One by one multiply n with  
            // individual digits of res[] 
            for (int i = 0; i < res_size; i++)
            {
                int prod = res[i] * x + carry;
                res[i] = prod % 10; // Store last digit of  
                // 'prod' in res[] 
                carry = prod / 10; // Put rest in carry 
            }

            // Put carry in res and 
            // increase result size 
            while (carry != 0)
            {
                res[res_size] = carry % 10;
                carry = carry / 10;
                res_size++;
            }
            return res_size;
        }




        
    }


    [TestFixture]
    public class LargeFactorialsTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(null, LargeFactorials.Factorial(-5));
            Assert.AreEqual("1", LargeFactorials.Factorial(1));
            Assert.AreEqual("120", LargeFactorials.Factorial(5));
            Assert.AreEqual("362880", LargeFactorials.Factorial(9));
            Assert.AreEqual("1307674368000", LargeFactorials.Factorial(15));
            Assert.AreEqual("93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000", LargeFactorials.Factorial(100));

        }
    }

}

