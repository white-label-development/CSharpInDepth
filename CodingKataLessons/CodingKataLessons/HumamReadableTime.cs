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
    // https://www.codewars.com/kata/52685f7382004e774f0001f7/train/csharp
    public class TimeFormat
    {

        //Write a function, which takes a non-negative integer(seconds) as input and returns the time in a human-readable format(HH:MM:SS)

        //HH = hours, padded to 2 digits, range: 00 - 99
        //MM = minutes, padded to 2 digits, range: 00 - 59
        //SS = seconds, padded to 2 digits, range: 00 - 59
        //The maximum time never exceeds 359999 (99:59:59)


        // my poor math let me down here. Should have used a modulo
        public static string GetReadableTime(int seconds)
        {
            var ts = TimeSpan.FromSeconds(seconds);
            int hh ; int mm; int ss;

            hh = ((int)ts.TotalHours);
            ts = ts.Subtract(TimeSpan.FromHours((int)ts.TotalHours));

            mm = ((int)ts.TotalMinutes);
            ts = ts.Subtract(TimeSpan.FromMinutes((int)ts.TotalMinutes));

            ss = ((int)ts.TotalSeconds);
            
            return (string.Format("{0:00}:{1:00}:{2:00}", hh, mm, ss));
        }

        // and the clever people did....


        public static string GetReadableTime1(int seconds)
        {
            return string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);  //awesome
        }

        public static string GetReadableTime2(int seconds)
        {
            var t = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:00}:{1:00}:{2:00}", (int)t.TotalHours, t.Minutes, t.Seconds); //wtf, I tried this but didn't think of casting hours to an int. silly me,
        }



    }

    [TestFixture]
    public class HumanReadableTimeTest
    {
        [Test]
        public void HumanReadableTest()
        {
            Assert.AreEqual("00:00:00", TimeFormat.GetReadableTime(0));
            Assert.AreEqual("00:00:05", TimeFormat.GetReadableTime(5));
            Assert.AreEqual("00:01:00", TimeFormat.GetReadableTime(60));
            Assert.AreEqual("23:59:59", TimeFormat.GetReadableTime(86399));
            Assert.AreEqual("99:59:59", TimeFormat.GetReadableTime(359999));
        }
    }

}

