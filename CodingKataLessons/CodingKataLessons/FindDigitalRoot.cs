using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingKataLessons
{
    class FindDigitalRoot
    {
        //In this kata, you must create a digital root function.
        //A digital root is the recursive sum of all the digits in a number.Given n, take the sum of the digits of n.
        //If that value has two digits, continue reducing in this way until a single-digit number is produced.
        //This is only applicable to the natural numbers.
        //Here's how it works:
        /*
         * digital_root(942)
            => 9 + 4 + 2
            => 15 ...
            => 1 + 5
            => 6
         */

        //mine
        public int DigitalRoot(long n)
        {
            // Your awesome code here!
            while (n > 9)
            {
                //long total = 0;
                //foreach (var c in n.ToString().ToCharArray()) { total += int.Parse(c.ToString()); }

                //swap foreach to .Aggregate
                long total = n.ToString().ToCharArray().Aggregate<char, long>(0, (current, c) => current + int.Parse(c.ToString()));

                n = total;
            }
            return (int)n;
        }

        //better versions:
        // n = n.ToString().ToCharArray().Sum(x => Convert.ToInt32( Convert.ToString(x))); //use Sum

        //love it
        public int DigitalRoot_VeryClever(long n)
        {
            return (int)(1 + (n - 1) % 9);
        }

        //recursive
        public long DigitalRoot_recursive(long n)
        {
            return n < 10 ? n : DigitalRoot(n / 10 + n % 10);
        }
    }
}
