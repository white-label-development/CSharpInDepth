using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingKataLessons.IpValidation
{
    class Kata
    {

        /*
         * Write an algorithm that will identify valid IPv4 addresses in dot-decimal format.
         * IPs should be considered valid if they consist of four octets, with values between 0 and 255, inclusive.

            Input to the function is guaranteed to be a single string.
         */

        public static bool is_valid_IP(string ipAddres)
        {
            var parts = ipAddres.Split('.');
            if (parts.Length != 4) return false;

            foreach (var octet in parts)
            {
                int num;
                if(!string.IsNullOrEmpty(octet) 
                   && octet.All(char.IsDigit) 
                   && int.TryParse(octet, out num) 
                   && string.Equals(num.ToString(), octet)
                   && num >= 0 && num <= 255) continue;
                return false;
            }

            return true;
        }


        //and the clever people did....

        //NT: LOL!!!!! there is an IpAddress class
        public static bool is_valid_IP_1(string IpAddres)
        {
            IPAddress ip;
            bool validIp = IPAddress.TryParse(IpAddres, out ip);
            return validIp && ip.ToString() == IpAddres;
        }

        //NT: the regex solution that was beyond me
        public static bool is_valid_IP_2(string IpAddres)
        {
            var octet = "([1-9][0-9]{0,2})";
            var reg = $@"{octet}\.{octet}\.{octet}\.{octet}";
            return new Regex(reg).IsMatch(IpAddres);
        }

        //this was accepted but it doesn't pass the tests (must be an early one) as it passes 12.34.56 , which is wrong.
        public static bool is_valid_IP_4(string IpAddres)
        {
            return (IpAddres.Count(c => c == '.') == 3) && IPAddress.TryParse(IpAddres, out IPAddress addr);
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void TestCases()
        {
            Assert.AreEqual(true, Kata.is_valid_IP("0.0.0.0"));
            Assert.AreEqual(true, Kata.is_valid_IP("12.255.56.1"));
            Assert.AreEqual(true, Kata.is_valid_IP("137.255.156.100"));

            Assert.AreEqual(false, Kata.is_valid_IP(""));
            Assert.AreEqual(false, Kata.is_valid_IP("abc.def.ghi.jkl"));
            Assert.AreEqual(false, Kata.is_valid_IP("123.456.789.0"));
            Assert.AreEqual(false, Kata.is_valid_IP("12.34.56"));
            Assert.AreEqual(false, Kata.is_valid_IP("12.34.56.00"));
            Assert.AreEqual(false, Kata.is_valid_IP("12.34.56.7.8"));
            Assert.AreEqual(false, Kata.is_valid_IP("12.34.256.78"));
            Assert.AreEqual(false, Kata.is_valid_IP("1234.34.56"));
            Assert.AreEqual(false, Kata.is_valid_IP("pr12.34.56.78"));
            Assert.AreEqual(false, Kata.is_valid_IP("12.34.56.78sf"));
            Assert.AreEqual(false, Kata.is_valid_IP("12.34.56 .1"));
            Assert.AreEqual(false, Kata.is_valid_IP("12.34.56.-1"));
            Assert.AreEqual(false, Kata.is_valid_IP("123.045.067.089"));
        }
    }
}
